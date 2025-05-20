using Telegram.Bot;
using Telegram.Bot.Types;
using System;
using System.Threading.Tasks;
using ENTITY;

namespace BLL
{
    public class BotServicioReserva
    {
        private readonly ReservaService _reservaService = new ReservaService();

        public async Task ManejarAcciones(ITelegramBotClient botClient, CallbackQuery callback)
        {
            var chatId = callback.Message.Chat.Id;

            switch (callback.Data)
            {
                case "RESERVAR":
                    await botClient.SendTextMessageAsync(
                        chatId,
                        "🗓 Ingresa tu reserva en este formato:\n\n`reservar id_cancha, dd-MM-yyyy, HH:mm, HH:mm`\n\nEjemplo: `reservar 2, 21-05-2025, 14:00, 15:30`",
                        Telegram.Bot.Types.Enums.ParseMode.Markdown);
                    break;

                case "CANCELAR":
                    await botClient.SendTextMessageAsync(
                        chatId,
                        "❌ Para cancelar una reserva, escribe:\n`cancelar ID_RESERVA`",
                        Telegram.Bot.Types.Enums.ParseMode.Markdown);
                    break;

                default:
                    await botClient.SendTextMessageAsync(chatId, "⚠️ Acción no reconocida.");
                    break;
            }
        }

        public async Task ProcesarTexto(ITelegramBotClient botClient, Message message)
        {
            var chatId = message.Chat.Id;
            string texto = message.Text.Trim().ToLower();

            if (texto.StartsWith("reservar"))
            {
                try
                {
                    string[] datos = texto.Replace("reservar", "").Split(',');

                    if (datos.Length < 4)
                    {
                        await botClient.SendTextMessageAsync(chatId, "⚠️ Formato inválido. Usa:\n`reservar id_cancha, dd-MM-yyyy, HH:mm, HH:mm`", Telegram.Bot.Types.Enums.ParseMode.Markdown);
                        return;
                    }

                    int idCancha = int.Parse(datos[0].Trim());
                    DateTime fecha = DateTime.ParseExact(datos[1].Trim(), "dd-MM-yyyy", null);
                    TimeSpan horaInicio = TimeSpan.Parse(datos[2].Trim());
                    TimeSpan horaFin = TimeSpan.Parse(datos[3].Trim());

                    // Simulación del usuario, puedes usar tu lógica para obtenerlo dinámicamente
                    int idUsuario = 1;

                    Reserva reserva = new Reserva
                    {
                        IdCancha = idCancha,
                        IdUsuario = idUsuario,
                        Fecha = fecha,
                        HoraInicio = horaInicio,
                        HoraFin = horaFin,
                        Estado = "Activa"
                    };

                    string resultado = _reservaService.Guardar(reserva);

                    await botClient.SendTextMessageAsync(chatId, $"📌 {resultado}");
                }
                catch (Exception ex)
                {
                    await botClient.SendTextMessageAsync(chatId, $"❌ Error al procesar la reserva: {ex.Message}");
                }
            }
        }
    }
}
