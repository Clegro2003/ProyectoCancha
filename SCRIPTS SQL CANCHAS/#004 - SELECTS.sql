SELECT id_cancha,estado  FROM cancha 

SELECT r.reserva_id, u.nombre, u.chatid, r.fecha, u.usuario_id,u.documento
FROM reserva r 
JOIN usuario u ON r.usuario_id = u.usuario_id


SELECT u.documento, r.usuario_id,r.fecha, r.horainicio, r.horafin, r.estado
FROM reserva r
JOIN usuario u ON r.usuario_id = u.usuario_id
WHERE u.usuario_id  = '2'

SELECT c.id_cancha , t.nombre_cancha , precio
FROM tipocancha t
JOIN cancha c ON t.id_tipocancha = c.id_tipocancha
WHERE c.estado = 'DISPONIBLE'

SELECT r.reserva_id, r.usuario_id, r.id_cancha, r.fecha, r.horainicio, r.horafin, r.estado
FROM reserva r
WHERE r.usuario_id = 25  AND r.estado = 'PENDIENTE'