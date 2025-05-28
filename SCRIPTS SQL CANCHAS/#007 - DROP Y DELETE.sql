ALTER TABLE pago DROP COLUMN estado

DELETE FROM reserva
WHERE usuario_id = 5;

DROP TABLE usuario;
DROP TABLE reserva;
DROP TABLE tipocancha; 
DROP TABLE cancha;
DROP TABLE pago;