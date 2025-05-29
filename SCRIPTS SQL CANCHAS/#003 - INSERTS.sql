-- Inserts para Usuario
INSERT INTO usuario (chatid, documento, nombre, apellido, telefono) VALUES
('123456789', '100000001', 'Carlos', 'Lopez', '3001112233'),
('987654321', '100000002', 'Laura', 'Gomez', '3002223344'),
('456123789', '100000003', 'Mateo', 'Rodriguez', '3013334455'),
('789456123', '100000004', 'Camila', 'Martinez', '3024445566');

-- Inserts para TipoCancha
INSERT INTO tipocancha (nombre_cancha) VALUES
('CON TECHO'),
('SIN TECHO'),
('CON TECHO'),
('SIN TECHO');

-- Inserts para MetodoPago
INSERT INTO metodopago (nombre_metodopago) VALUES
('Efectivo'),
('Nequi'),
('Transferencia Bancaria');

-- Inserts para Cancha
INSERT INTO cancha (id_tipocancha, estado, precio) VALUES
(1, 'DISPONIBLE', 30000.00),
(2, 'OCUPADO', 25000.00),
(1, 'OCUPADO', 28000.00),
(2, 'DISPONIBLE', 27000.00);

-- Inserts para Reserva
INSERT INTO reserva (usuario_id, id_cancha, fecha, horainicio, horafin, estado) VALUES
(2, 2, '2025-05-26', '09:00', '10:00', 'PENDIENTE'),
(3, 3, '2025-05-27', '10:00', '11:00', 'PENDIENTE'),
(4, 4, '2025-05-28', '11:00', '12:00', 'PAGADO');

-- Inserts para Pago
INSERT INTO pago (reserva_id, id_metodopago, fecha, estado, monto) VALUES
(9, 2, '2025-05-26', 'PENDIENTE', 25000.00),
(10, 3, '2025-05-27', 'PENDIENTE', 28000.00),
(11, 1, '2025-05-28', 'REALIZADO', 27000.00);

-- Reservas para el 10 de abril de 2025
INSERT INTO reserva (usuario_id, id_cancha, fecha, horainicio, horafin, estado) VALUES
(27, 1, '2025-04-10', '08:00', '09:00', 'PAGADO'),
(27, 2, '2025-04-10', '09:00', '10:00', 'PENDIENTE'),
(27, 3, '2025-04-10', '10:00', '11:00', 'PAGADO'),
(27, 4, '2025-04-10', '11:00', '12:00', 'PAGADO');

-- Reservas para el 15 de mayo de 2025
INSERT INTO reserva (usuario_id, id_cancha, fecha, horainicio, horafin, estado) VALUES
(27, 1, '2025-05-15', '08:00', '09:00', 'PAGADO'),
(27, 2, '2025-05-15', '09:00', '10:00', 'PAGADO'),
(27, 3, '2025-05-15', '10:00', '11:00', 'PENDIENTE'),
(27, 4, '2025-05-15', '11:00', '12:00', 'PAGADO');

-- Reservas para el 20 de junio de 2025
INSERT INTO reserva (usuario_id, id_cancha, fecha, horainicio, horafin, estado) VALUES
(27, 1, '2025-06-20', '08:00', '09:00', 'PAGADO'),
(27, 2, '2025-06-20', '09:00', '10:00', 'PENDIENTE'),
(27, 3, '2025-06-20', '10:00', '11:00', 'PAGADO'),
(27, 4, '2025-06-20', '11:00', '12:00', 'PAGADO');
 
-- 4 reservas para el 15 de mayo de 2025
INSERT INTO reserva (usuario_id, id_cancha, fecha, horainicio, horafin, estado) VALUES
(27, 1, '2025-05-15', '08:00', '09:00', 'PAGADO'),
(27, 2, '2025-05-15', '09:00', '10:00', 'PAGADO'),
(27, 3, '2025-05-15', '10:00', '11:00', 'PENDIENTE'),
(27, 4, '2025-05-15', '11:00', '12:00', 'PAGADO');

-- 4 reservas en otras fechas de mayo
INSERT INTO reserva (usuario_id, id_cancha, fecha, horainicio, horafin, estado) VALUES
(27, 1, '2025-05-10', '08:00', '09:00', 'PENDIENTE'),
(27, 2, '2025-05-20', '09:00', '10:00', 'PAGADO'),
(27, 3, '2025-05-25', '10:00', '11:00', 'PAGADO'),
(27, 4, '2025-05-26', '11:00', '12:00', 'PENDIENTE');

-- 5 reservas en los últimos 7 días (desde el 21 al 27 de mayo)
INSERT INTO reserva (usuario_id, id_cancha, fecha, horainicio, horafin, estado) VALUES
(27, 1, '2025-05-21', '14:00', '15:00', 'PAGADO'),
(27, 2, '2025-05-23', '15:00', '16:00', 'PAGADO'),
(27, 3, '2025-05-24', '16:00', '17:00', 'PAGADO'),
(27, 4, '2025-05-26', '17:00', '18:00', 'PENDIENTE'),
(27, 1, '2025-05-27', '18:00', '19:00', 'PAGADO');

-- 4 reservas para el 28 de mayo de 2025
INSERT INTO reserva (usuario_id, id_cancha, fecha, horainicio, horafin, estado) VALUES
-- Mismo horario (08:00 - 09:00) en distintas canchas
(27, 1, '2025-05-28', '08:00', '09:00', 'PAGADO'),
(27, 2, '2025-05-28', '08:00', '09:00', 'PAGADO'),

-- Otros horarios
(27, 3, '2025-05-28', '09:00', '10:00', 'PENDIENTE'),
(27, 4, '2025-05-28', '17:00', '18:00', 'PAGADO');
