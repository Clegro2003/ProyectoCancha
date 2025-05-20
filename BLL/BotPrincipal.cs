using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using ENTITY;
using DAL;

namespace BLL
{
    public class BotPrincipal
    {
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
            if (update.Message is Message message && message.Text != null)
            {
                var text = message.Text.Trim();
                var chatId = message.Chat.Id;

                if (text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(
                        chatId,
                        "👋 Hola. Ingresa tus datos:\n`documento, nombre, apellido, telefono`",
                        Telegram.Bot.Types.Enums.ParseMode.Markdown,
                        cancellationToken: token);
                    return;
                }

                // Registro de usuario
                var partes = text.Split(',');
                if (partes.Length == 4)
                {
                    var usuario = new Usuario
                    {
                        Documento = partes[0].Trim(),
                        Nombre = partes[1].Trim(),
                        Apellido = partes[2].Trim(),
                        Telefono = partes[3].Trim()
                    };

                    var resultado = usuarioRepo.Guardar(usuario);
                    await botClient.SendTextMessageAsync(chatId, resultado, cancellationToken: token);

                    if (resultado.StartsWith("Okey"))
                    {
                        var menu = new InlineKeyboardMarkup(new[]
                        {
                            new[] {
                                InlineKeyboardButton.WithCallbackData("RESERVAR"),
                                InlineKeyboardButton.WithCallbackData("CANCELAR")
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
                if (text.ToLower().StartsWith("reservar") || text.ToLower().StartsWith("cancelar"))
                {
                    await reservaService.ProcesarTexto(botClient, message);
                    return;
                }
                await botClient.SendTextMessageAsync(chatId, "❓ No entendí tu mensaje. Usa /start para comenzar.", cancellationToken: token);
            }

            // Manejo de botones
            if (update.CallbackQuery != null)
            {
                await reservaService.ManejarAcciones(botClient, update.CallbackQuery);
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
