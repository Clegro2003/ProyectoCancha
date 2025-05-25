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

namespace BLL
{
    public class BotPrincipal
    {
        Dictionary<string, string> chats = new Dictionary<string, string>();
        private TelegramBotClient botClient;
        private UsuarioRepository usuarioRepo;
        private BotServicioReserva reservaService;

        public void Iniciar()
        {
            usuarioRepo = new UsuarioRepository();
            reservaService = new BotServicioReserva();
            botClient = new TelegramBotClient("7631036294:AAEkN7eNU-q8h0t_gKVkXZs-qeJauFCzkzw");
            StartReceiver();
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

                if (text.ToLower() == "/start")
                {
                    //chats.Add(chatId.ToString(), "INICIO");
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

                    string resultado = usuarioRepo.Guardar(usuario);
                    await botClient.SendTextMessageAsync(chatId, resultado, cancellationToken: token);

                    if (resultado.StartsWith("Okey"))
                    {


                        var menu = new InlineKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                InlineKeyboardButton.WithCallbackData("RESERVAR CANCHA"),
                                InlineKeyboardButton.WithCallbackData("CANCELAR RESERVA DE CANCHA")
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

                await reservaService.ProcesarTexto(botClient, message, chats);
                
            }

            // Manejo de botones
            if (update.CallbackQuery != null)
            {
                await reservaService.ManejarAcciones(botClient, update.CallbackQuery,chats);
            }
            //await reservaService.ProcesarTexto(botClient, message);


        }

        private Task OnError(ITelegramBotClient botClient, Exception exception, CancellationToken token)
        {
            Console.WriteLine($"❌ Error: {exception.Message}");
            return Task.CompletedTask;
        }
    }
}
