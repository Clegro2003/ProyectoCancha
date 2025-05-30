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
        BotPrincipal _BotPrincipal = new BotPrincipal();

        public async Task ManejarAcciones(ITelegramBotClient botClient, CallbackQuery callback, Dictionary<string, string> chats, CancellationToken token)
        {
            var chatId = callback.Message.Chat.Id;
            Reserva reserva = new Reserva();
            var usuario = usuarioService.ConsultarPorChatID(chatId.ToString());


            switch (callback.Data)
            {
                
                case "RESERVAR \nCANCHA":
                    var canchas = tipocancha.Consultar();
                    Console.WriteLine("jhgfdsxcvbnmlgfdnmkgfc");
                    await botClient.SendTextMessageAsync(chatId, "TIPO DE CANCHA\n " + String.Join("\n", canchas)
                                                            + $"\n¿Cual deseas {usuario.Nombre} {usuario.Apellido} ?",
                                                            Telegram.Bot.Types.Enums.ParseMode.Markdown);

                    chats[chatId.ToString()] = "RESERVA";

                    break;

                case "CANCELAR RESERVA \nDE CANCHA":
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

                case "REALIZAR PAGO \nDE RESERVA":
                    await botClient.SendTextMessageAsync(chatId, "LISTA DE RERSERVAS A PAGAR PENDIENTES");

                    var Reservas = _reservaService.ConsultarReservas(usuario.Usuario_id);
                    var Pendientes = Reservas.Where(r => r.Estado != null && r.Estado.Trim().ToUpper() == "PENDIENTE").ToList();

                    await botClient.SendTextMessageAsync(chatId, $"🔍 Total reservas encontradas: {Pendientes.Count}");
                    if (Pendientes.Count == 0)
                    {
                        await botClient.SendTextMessageAsync(chatId, "⛔ No tienes reservas pendientes.");
                        return;
                    }

                    var listaPagos = string.Join("\n", Pendientes.Select(r =>
                        $"ID: {r.IdReserva} | Cancha: {r.IdCancha} | Fecha: {r.Fecha:dd-MM-yyyy} {r.HoraInicio}-{r.HoraFin}"));

                    await botClient.SendTextMessageAsync(
                        chatId,
                        $"Estas son tus reservas pendientes:\n{listaPagos}\n\nEscribe el ID de la reserva que deseas pagar.",
                        Telegram.Bot.Types.Enums.ParseMode.Markdown);

                    chats[chatId.ToString()] = "REALIZAR_PAGO";
                    break;
                default:
                    await botClient.SendTextMessageAsync(chatId, "⚠️ Acción no reconocida.");
                    break;
            }
        }

        private async Task MostrarMenuPrincipal(ITelegramBotClient botClient, long chatId, string nombreUsuario, CancellationToken token)
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

            await botClient.SendTextMessageAsync(chatId, $"🔁 ¿Qué deseas hacer ahora, {nombreUsuario}?", replyMarkup: menu, cancellationToken: token);
        }


        public async Task ProcesarTexto(ITelegramBotClient botClient, Message message, Dictionary<string, string> chats, CancellationToken token)
        {
            var chatId = message.Chat.Id;
            string texto = message.Text.Trim().ToLower();
            var contexto = chats[chatId.ToString()];
            var usuario = usuarioService.ConsultarPorChatID(chatId.ToString());


            if (contexto == "RESERVA")
            {

                if (texto == "1" || texto == "2")
                {
                    int tipoId = int.Parse(texto);

                    var canchasFiltradas = canchaRepository.ConsultarDisponible()
                                            .Where(c => c.TipoCanchaId.TipoId == tipoId).ToList();

                    if (canchasFiltradas.Count == 0)
                    {
                        await botClient.SendTextMessageAsync(chatId, "⛔ No hay canchas disponibles para ese tipo.");
                        return;
                    }

                    var mensaje = "🏟️ Canchas disponibles:\n\n" +
                                  string.Join("\n", canchasFiltradas.Select(c =>
                                     $"ID: {c.Id_cancha} | Precio: {c.Precio}"));

                    mensaje += "\n\n📝 Ahora escribe en el formato:\n`ID Cancha, Fecha así: dd-MM-yyyy, Hora inicio, Hora final`";

                    await botClient.SendTextMessageAsync(chatId, mensaje, Telegram.Bot.Types.Enums.ParseMode.Markdown);

                    return;
                }

                string[] datos = texto.Replace("reservar", "").Split(',');
                if (datos.Length < 4)
                {
                    await botClient.SendTextMessageAsync(chatId, "⚠️ Formato inválido. Usa:\n`id_cancha, dd-MM-yyyy, HH:mm, HH:mm`",
                        Telegram.Bot.Types.Enums.ParseMode.Markdown);
                    return;
                }

                try
                {
                    int idCancha = int.Parse(datos[0].Trim());
                    DateTime fecha = DateTime.ParseExact(datos[1].Trim(), "dd-MM-yyyy", null);
                    TimeSpan horaInicio = TimeSpan.Parse(datos[2].Trim());
                    TimeSpan horaFin = TimeSpan.Parse(datos[3].Trim());



                    if (fecha.Date < DateTime.Today)
                    {
                        await botClient.SendTextMessageAsync(chatId, "❌ No puedes reservar una fecha pasada.");
                        return;
                    }

                    if (horaInicio >= horaFin)
                    {
                        await botClient.SendTextMessageAsync(chatId, "❌ La hora de inicio debe ser menor que la hora de fin.");
                        return;
                    }

                    var reservasExistentes = _reservaService.ConsultarPorCanchaYFecha(idCancha, fecha);

                    var hayConflicto = reservasExistentes.Any(r => horaInicio < r.HoraFin && horaFin > r.HoraInicio);

                    if (hayConflicto)
                    {
                        await botClient.SendTextMessageAsync(chatId, "⛔ La cancha ya está reservada en ese horario.");
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
                    chats[chatId.ToString()] = "MENU";
                    await MostrarMenuPrincipal(botClient, chatId, usuario.Nombre, CancellationToken.None);
                }
                catch (Exception ex)
                {
                    await botClient.SendTextMessageAsync(chatId, $"❌ Error al procesar la reserva: {ex.Message}");
                }
            }
            else if (contexto == "CANCELAR")
            {
                try
                {
                    int idReserva = int.Parse(texto.Trim());
                    var resultado = _reservaService.Cancelar(idReserva);
                    await botClient.SendTextMessageAsync(chatId, resultado);
                    chats[chatId.ToString()] = "MENU";
                    await MostrarMenuPrincipal(botClient, chatId, usuario.Nombre, CancellationToken.None);
                }
                catch
                {
                    await botClient.SendTextMessageAsync(chatId, "❌ ID inválido. Intenta de nuevo.");
                }
            }
            else if (contexto == "REALIZAR_PAGO")
            {
                try
                {
                    int idReserva = int.Parse(texto.Trim());

                    string rutaImagen = "C:\\Users\\carlo\\Downloads\\Proyecto de Aula P3\\Proyecto_Cancha\\IMAGENES\\qr-prueba-2.jpg";
                    using (var stream = System.IO.File.OpenRead(rutaImagen))
                    {
                        await botClient.SendPhotoAsync(
                            chatId: chatId,
                            photo: new Telegram.Bot.Types.InputFiles.InputOnlineFile(stream, "qr_reserva.jpeg"),
                            caption: "Pago realizado con éxito ✅"
                        );
                    }

                    var resultado = _reservaService.Modificar(idReserva);
                    await botClient.SendTextMessageAsync(chatId, resultado);

                    chats[chatId.ToString()] = "MENU";
                    await MostrarMenuPrincipal(botClient, chatId, usuario.Nombre, CancellationToken.None);
                }
                catch
                {
                    await botClient.SendTextMessageAsync(chatId, "❌ Error al procesar el pago. Asegúrate de ingresar un ID válido.");
                }

                return;
            }

        }
    }
}

