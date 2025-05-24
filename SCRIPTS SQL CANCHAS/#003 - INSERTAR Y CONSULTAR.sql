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

select usuario_id,documento,nombre from postgres."CanchasDB".usuario


SELECT * FROM postgres."CanchasDB".metodopago

select * from reserva

SELECT id_cancha,estado  FROM cancha 
SELECT c.id_cancha , t.nombre_cancha , precio
FROM tipocancha t
JOIN cancha c ON t.id_tipocancha = c.id_tipocancha
WHERE c.estado = 'DISPONIBLE'

drop table usuario;
drop table reserva;
drop table tipocancha; 
drop table cancha;
drop table metodopago;
drop table pago;