using Telegram.Bot;
using Telegram.Bot.Types;
using System;
using System.Threading.Tasks;
using ENTITY;
using DAL;
using System.Linq;
using System.Collections.Generic;

namespace BLL
{
    public class BotServicioReserva
    {
        private readonly ReservaService _reservaService = new ReservaService();
        TipoCanchaRepository tipocancha = new TipoCanchaRepository();
        UsuarioService usuarioService = new UsuarioService();
        CanchaRepository canchaRepository = new CanchaRepository();

        
        public async Task ManejarAcciones(ITelegramBotClient botClient, CallbackQuery callback, Dictionary<string, string> chats)
        {
            var chatId = callback.Message.Chat.Id;

            switch (callback.Data)
            {

                case "RESERVAR CANCHA":
                    var canchas = canchaRepository.ConsultarDisponible().Select(x => x.Id_cancha+": "+x.Nombre_Cancha+" Precio: "+x.Precio);
                    await botClient.SendTextMessageAsync(
                        chatId,"Tipos de canchas:\n "+
                        String.Join("\n",canchas)+
                        "\n🗓 Ingresa tu reserva en este formato:\n\n`tipocancha, Fecha, Hora inicio, Hora fin`\n\n" +
                        "Ejemplo: `2, 21-05-2025, 14:00, 15:30`",
                        Telegram.Bot.Types.Enums.ParseMode.Markdown);
                        chats[chatId.ToString()] = "RESERVA";
                    break;

                case "CANCELAR RESERVA DE CANCHA":
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

        public async Task ProcesarTexto(ITelegramBotClient botClient, Message message, Dictionary<string, string> chats)
        {
            var chatId = message.Chat.Id;
            string texto = message.Text.Trim().ToLower();
            var contexto = chats[chatId.ToString()];
            if (contexto == "RESERVA")
            {
                try
                {
                    string[] datos = texto.Replace("reservar", "").Split(',');

                    if (datos.Length < 4)
                    {
                        await botClient.SendTextMessageAsync(chatId, "⚠️ Formato inválido. Usa:\n`reservar id_cancha, dd-MM-yyyy, " +
                                                                     "HH:mm, HH:mm`", Telegram.Bot.Types.Enums.ParseMode.Markdown);
                        return;
                    }

                    int idCancha = int.Parse(datos[0].Trim());
                    DateTime fecha = DateTime.ParseExact(datos[1].Trim(), "dd-MM-yyyy", null);
                    TimeSpan horaInicio = TimeSpan.Parse(datos[2].Trim());
                    TimeSpan horaFin = TimeSpan.Parse(datos[3].Trim());

                    // Simulación del usuario, puedes usar tu lógica para obtenerlo dinámicamente
                    var usuario = usuarioService.ConsultarPorChatID(chatId.ToString());
                    if (usuario == null)
                    {
                        await botClient.SendTextMessageAsync(chatId, "Usuario no reconocido.");
                        return;
                    }
                        Reserva reserva = new Reserva
                        {
                            IdCancha = idCancha,
                            IdUsuario = usuario.Usuario_id,
                            Fecha = fecha,
                            HoraInicio = horaInicio,
                            HoraFin = horaFin,
                            Estado = "PENDIENTE"
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
