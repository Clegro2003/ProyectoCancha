using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using ENTITY;
using DAL;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BLL
{
    public class BotPrincipal
    {
        Dictionary<string, string> chats = new Dictionary<string, string>();
        private TelegramBotClient botClient;
        private UsuarioRepository usuarioRepo;
        private BotServicioReserva reservaService;
        private UsuarioService usuarioService;

        public void Iniciar()
        {
            botClient = new TelegramBotClient("7631036294:AAEkN7eNU-q8h0t_gKVkXZs-qeJauFCzkzw");
            StartReceiver();
            usuarioRepo = new UsuarioRepository();
            reservaService = new BotServicioReserva();
            usuarioService = new UsuarioService();
        }

        private async void StartReceiver()
        {
            var cts = new CancellationTokenSource();
            var opt = new ReceiverOptions { AllowedUpdates = { } };
            await botClient.ReceiveAsync(OnUpdate, OnError, opt, cts.Token);
        }


        private async Task OnUpdate(ITelegramBotClient client, Update update, CancellationToken token)
        {
            if (update.Message is Telegram.Bot.Types.Message message)
            {
                string text = message.Text?.Trim();
                var chatId = message.Chat.Id;

                if (!chats.ContainsKey(chatId.ToString()))
                {

                    var usuarioExistente = usuarioRepo.ConsultarPorChatID(chatId.ToString());
                    if (usuarioExistente != null)
                    {
                        chats[chatId.ToString()] = "MENU";

                        var menu = new InlineKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData("RESERVAR \nCANCHA"),
                                InlineKeyboardButton.WithCallbackData("CANCELAR RESERVA \nDE CANCHA"),
                                InlineKeyboardButton.WithCallbackData("REALIZAR PAGO \nDE RESERVA")
                            }
                        });

                        await botClient.SendTextMessageAsync
                        (
                            chatId,
                            $"👋 ¡Hola {usuarioExistente.Nombre}!",
                            cancellationToken: token
                        );

                        await botClient.SendTextMessageAsync(chatId, "¿Qué deseas hacer ahora?", replyMarkup: menu, 
                                                             cancellationToken: token);

                        return;

                    }

                    chats[chatId.ToString()] = "INICIO";

                    await botClient.SendTextMessageAsync(
                        chatId,
                        "👋 Bienvenido. Escribe tus datos así:\n`documento, nombre, apellido, telefono`",
                        parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                        cancellationToken: token
                    );


                    return;
                }



                if (!chats.ContainsKey(chatId.ToString()))
                    return;

                var contexto = chats[chatId.ToString()];
                
                if (contexto == "INICIO")
                {

                    var partes = text.Split(',');

                    var usuario = new Usuario
                    {
                        ChatID = chatId.ToString(),
                        Documento = partes[0].Trim(),
                        Nombre = partes[1].Trim(),
                        Apellido = partes[2].Trim(),
                        Telefono = partes[3].Trim()
                    };

                    if (string.IsNullOrWhiteSpace(usuario.Documento) || usuario.Documento.Length != 10 || !usuario.Documento.All(char.IsDigit))
                    {
                        await botClient.SendTextMessageAsync(chatId, "⚠️ Tu documento debe tener 10 caracteres y solo numerico.");
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(usuario.Telefono) || usuario.Telefono.Length != 10 || !usuario.Telefono.All(char.IsDigit))
                    {
                        await botClient.SendTextMessageAsync(chatId, "⚠️ Tu teléfono debe tener 10 caracteres y solo numerico.");
                        return;
                    }
                    var ExisteDocumento = usuarioService.ConsultatPorID(usuario.Documento.ToString());

                    if (ExisteDocumento)
                    {
                        await botClient.SendTextMessageAsync(chatId, "⚠️ El documento ya está registrado. No puedes usar el mismo.");
                        return;
                    }

                    string resultado = usuarioRepo.Guardar(usuario);
                    await botClient.SendTextMessageAsync(chatId, resultado, cancellationToken: token);

                    if (resultado.StartsWith("Okey... Perfecto"))
                    {


                        var menu = new InlineKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData("RESERVAR \nCANCHA"),
                                InlineKeyboardButton.WithCallbackData("CANCELAR RESERVA \nDE CANCHA"),
                                InlineKeyboardButton.WithCallbackData("REALIZAR PAGO \nDE RESERVA")

                            }
                        });

                        await botClient.SendTextMessageAsync(
                            chatId,
                            "✅ Registro exitoso. ¿Qué deseas hacer?",
                            replyMarkup: menu,
                            cancellationToken: token
                        );
                    }

                    return;
                }

                await reservaService.ProcesarTexto(botClient, message, chats, token);
                
            }

            if (update.CallbackQuery != null)
            {
                await reservaService.ManejarAcciones(botClient, update.CallbackQuery,chats,token);
            }


        }

        private Task OnError(ITelegramBotClient botClient, Exception exception, CancellationToken token)
        {
            Console.WriteLine($"❌ Error: {exception.Message}");
            return Task.CompletedTask;
        }
    }
}