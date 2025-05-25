using Telegram.Bot;
using Telegram.Bot.Types;
using System;
using System.Threading.Tasks;
using ENTITY;
using DAL;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Telegram.Bot.Types.ReplyMarkups;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace BLL
{
    public class BotServicioReserva
    {
        ReservaService _reservaService = new ReservaService();
        TipoCanchaRepository tipocancha = new TipoCanchaRepository();
        UsuarioService usuarioService = new UsuarioService();
        CanchaRepository canchaRepository = new CanchaRepository();

        
        public async Task ManejarAcciones(ITelegramBotClient botClient, CallbackQuery callback, Dictionary<string, string> chats, CancellationToken token)
        {
            var chatId = callback.Message.Chat.Id;
            Reserva reserva = new Reserva();
            var usuario = usuarioService.ConsultarPorChatID(chatId.ToString());
            
            switch (callback.Data)
            {

                case "RESERVAR CANCHA":
                    var canchas = canchaRepository.ConsultarDisponible().Select(x => x.Id_cancha + ": " + x.Nombre_Cancha + " " +
                                                                                "Precio: " + x.Precio);

                    //var tipocacancha = new InlineKeyboardMarkup(new[]
                    //{
                    //    new[]
                    //    {
                    //        InlineKeyboardButton.WithCallbackData("CON TECHO"),
                    //        InlineKeyboardButton.WithCallbackData("SIN TECHO")
                    //    }
                    //});


                    await botClient.SendTextMessageAsync(chatId, "TIPOS DE CANCHA", replyMarkup: tipocacancha,
                                                             cancellationToken: token);
                    //await botClient.SendTextMessageAsync(chatId,$"¿Cual deseas {usuario.Nombre} {usuario.Apellido} ?", 
                    //                                        Telegram.Bot.Types.Enums.ParseMode.Markdown);

                    chats[chatId.ToString()] = "RESERVA";

                    break;

                case "CON TECHO":
                case "SIN TECHO":
                    var tipoSeleccionado = callback.Data;
                    var tipo = tipocancha.ConsultarPorNombre(tipoSeleccionado);

                    //var canchasFiltradas = canchaRepository.ConsultarDisponible()
                    //                    .Where(c => c.TipoCancha == tipo.).Select(c => $"{c.Id_cancha}: {c.Nombre_Cancha} - ${c.Precio}");

                    chats[chatId.ToString()] = "RESERVA";
                    break;

                case "CANCELAR RESERVA DE CANCHA":
                    if (usuario == null)
                    {
                        await botClient.SendTextMessageAsync(chatId, "⚠️ No estás registrado.");
                        return;
                    }

                    await botClient.SendTextMessageAsync(chatId, $"🆔 Usuario ID consultado: {usuario.Usuario_id}");

                    var todasReservas = _reservaService.ConsultarReservas(usuario.Usuario_id);
                    var reservasPendientes = todasReservas.Where(r => r.Estado != null && r.Estado.Trim().ToUpper() == "PENDIENTE").ToList();

                    await botClient.SendTextMessageAsync(chatId, $"🔍 Total reservas encontradas: {reservasPendientes.Count}");
                    if (reservasPendientes.Count == 0)
                    {
                        await botClient.SendTextMessageAsync(chatId, "⛔ No tienes reservas pendientes.");
                        return;
                    }

                    var lista = string.Join("\n", reservasPendientes.Select(r =>
                        $"ID: {r.IdReserva} | Cancha: {r.IdCancha} | Fecha: {r.Fecha:dd-MM-yyyy} {r.HoraInicio}-{r.HoraFin}"));

                    await botClient.SendTextMessageAsync(
                        chatId,
                        $"Estas son tus reservas pendientes:\n{lista}\n\nEscribe el ID que deseas cancelar.",
                        Telegram.Bot.Types.Enums.ParseMode.Markdown);
                        chats[chatId.ToString()] = "CANCELAR";
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
            }else if (contexto == "CANCELAR")
            {
                try
                {
                    int idReserva = int.Parse(texto.Trim());
                    var resultado = _reservaService.Cancelar(idReserva);
                    await botClient.SendTextMessageAsync(chatId, resultado);
                }
                catch
                {
                    await botClient.SendTextMessageAsync(chatId, "❌ ID inválido. Intenta de nuevo.");
                }
            }
        }
    }
}
