using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot;
using ENTITY;
using DAL;
using Telegram.Bot.Types.ReplyMarkups;

namespace BLL
{
    public class BotService
    {
        TelegramBotClient botClient;
        UsuarioRepository usuarioRepo;

        public void Bot()
        {
            usuarioRepo = new UsuarioRepository();
            botClient = new TelegramBotClient("7631036294:AAEkN7eNU-q8h0t_gKVkXZs-qeJauFCzkzw");
            StartReciver();
        }


        public async Task StartReciver()
        {
            var token = new CancellationTokenSource();
            var Canceltoken = token.Token;
            var ReOpt = new ReceiverOptions { AllowedUpdates = { } };
            await botClient.ReceiveAsync(Onmessage, ErrorMessage, ReOpt, Canceltoken);
        }

        private async Task ErrorMessage(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            if (exception is ApiRequestException requestException)
            {
                await botClient.SendTextMessageAsync("", exception.Message.ToString());
            }
        }

        /*private async Task Onmessage(ITelegramBotClient client, Update update, CancellationToken token)
        {

            if (update.Message is Telegram.Bot.Types.Message messages)
            {
                string text = messages.Text.Trim();

                if (text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(
                        chatId: messages.Chat.Id,
                        text: "Hola 👋\nPor favor escribe tus datos separados por comas:\n" +
                              "Formato: `documento, nombre, apellido, telefono`",
                        parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                        cancellationToken: token
                    );
                    return;
                }

                var partes = text.Split(',');

                if (partes.Length < 4)
                {
                    await botClient.SendTextMessageAsync(
                        chatId: messages.Chat.Id,
                        text: "❌ Formato incorrecto. Usa: documento, nombre, apellido, telefono",
                        cancellationToken: token
                    );
                    return;
                }

                var usuario = new Usuario
                {
                    Documento = partes[0].Trim(),
                    Nombre = partes[1].Trim(),
                    Apellido = partes[2].Trim(),
                    Telefono = partes[3].Trim()
                };

                // Guardar en BD (DAL)
                string resultado = usuarioRepo.Guardar(usuario);

                await botClient.SendTextMessageAsync(
                    chatId: messages.Chat.Id,
                    text: resultado,
                    cancellationToken: token
                );

               

                if (resultado.StartsWith("Okey... Perfecto"))
                {
                    var menu = new InlineKeyboardMarkup(new[]
                    {
                        new[] {
                            InlineKeyboardButton.WithCallbackData("RESERVAR CANCHA"),
                            InlineKeyboardButton.WithCallbackData("CANCELAR RESERVA DE CANCHA")
                        }
                        //new[] {
                        //    InlineKeyboardButton.WithCallbackData("")
                        //}
                    });

                    await botClient.SendTextMessageAsync(
                        chatId: messages.Chat.Id,
                        text: "Que servicio necesitas. Elige una opción:",
                        replyMarkup: menu,
                        cancellationToken: token
                    );

                }

                if (update.CallbackQuery != null)
                {
                    var callback = update.CallbackQuery;

                    await botClient.SendTextMessageAsync(
                        chatId: callback.Message.Chat.Id,
                        text: $"Elegiste la opción: {callback.Data}",
                        cancellationToken: token
                    );
                }
            }
        }*/

        private async Task Onmessage(ITelegramBotClient client, Update update, CancellationToken token)
        {
            if (update.Message is Telegram.Bot.Types.Message message)
            {
                string text = message.Text?.Trim();
                var chatId = message.Chat.Id;

                // Comando inicial
                if (text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(
                        chatId,
                        "👋 Bienvenido. Escribe tus datos así:\n`documento, nombre, apellido, telefono`",
                        parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                        cancellationToken: token
                    );
                    return;
                }

                // Intento de registrar usuario
                if (text.Split(',').Length == 4)
                {
                    var partes = text.Split(',');

                    var usuario = new Usuario
                    {
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
                    new[] {
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

                // Detectar intento de reserva por formato (3 valores)
                if (text.Split(',').Length == 3)
                {
                    // Se espera: "dd-MM-yyyy, HH:mm, HH:mm"
                    var partes = text.Split(',');

                    if (DateTime.TryParse(partes[0], out DateTime fecha) &&
                        TimeSpan.TryParse(partes[1], out TimeSpan horaInicio) &&
                        TimeSpan.TryParse(partes[2], out TimeSpan horaFin))
                    {
                        // Aquí podrías llamar a la DAL de Reserva y guardar:
                        await botClient.SendTextMessageAsync(chatId, $"📅 Reserva registrada para el {fecha:dd-MM-yyyy}, de {horaInicio} a {horaFin}", cancellationToken: token);
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId, "❌ Formato incorrecto. Intenta: `dd-MM-yyyy, HH:mm, HH:mm`", cancellationToken: token);
                    }

                    return;
                }

                // Posible intento de cancelación
                if (text.StartsWith("cancelar", StringComparison.OrdinalIgnoreCase))
                {
                    string[] palabras = text.Split(' ');
                    if (palabras.Length >= 2 && int.TryParse(palabras[1], out int idReserva))
                    {
                        // Aquí llamas a DAL para eliminar o cambiar estado
                        await botClient.SendTextMessageAsync(chatId, $"❌ Reserva #{idReserva} cancelada (simulado)", cancellationToken: token);
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId, "❌ Escribe: cancelar [ID_RESERVA]", cancellationToken: token);
                    }

                    return;
                }

                // Si nada coincide
                await botClient.SendTextMessageAsync(chatId, "⚠️ No entendí tu mensaje. Usa /start para comenzar.", cancellationToken: token);
            }

            // --- Manejo de botones (callback) ---
            if (update.CallbackQuery != null)
            {
                var callback = update.CallbackQuery;
                var chatId = callback.Message.Chat.Id;

                switch (callback.Data)
                {
                    case "RESERVAR CANCHA":
                        await botClient.SendTextMessageAsync(
                            chatId,
                            "🗓 Ingresa: `dd-MM-yyyy, HH:mm, HH:mm` para reservar.",
                            parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                            cancellationToken: token
                        );
                        break;

                    case "CANCELAR RESERVA DE CANCHA":
                        await botClient.SendTextMessageAsync(
                            chatId,
                            "❌ Ingresa: `cancelar [ID_RESERVA]` para cancelar tu reserva.",
                            cancellationToken: token
                        );
                        break;

                    default:
                        await botClient.SendTextMessageAsync(chatId, "Opción no reconocida", cancellationToken: token);
                        break;
                }
            }
        }

    }

}
