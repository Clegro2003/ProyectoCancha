-- Crear Tabla Usuario, primera tabla a crear
CREATE TABLE usuario(
	usuario_id SERIAL PRIMARY KEY,
	chatid TEXT NOT NULL,
	documento VARCHAR(25) NOT NULL,
	nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50),
    telefono VARCHAR(50) NOT NULL
);

-- Segunda tabla a crear
CREATE TABLE tipocancha (
    id_tipoCancha SERIAL PRIMARY KEY,
    nombre_cancha VARCHAR(20) CHECK (nombre_cancha IN ('CON TECHO', 'SIN TECHO'))
);

-- cuarta tabla a crear
CREATE TABLE cancha (
    id_cancha SERIAL PRIMARY KEY,
    id_tipocancha INT NOT NULL,
    estado VARCHAR(20) CHECK (estado IN ('DISPONIBLE', 'OCUPADO')),
    precio numeric(10, 2),
    CONSTRAINT fk_tipo_cancha FOREIGN KEY (id_tipocancha) REFERENCES tipocancha(id_tipocancha) ON DELETE CASCADE
);

SELECT c.id_cancha , c.precio
FROM tipocancha t
JOIN cancha c ON t.id_tipocancha = c.id_tipocancha
WHERE c.estado = 'DISPONIBLE' AND c.id_tipocancha = 2

-- Quinta tabla a crear
CREATE TABLE reserva(
	reserva_id SERIAL PRIMARY KEY,
	usuario_id INT NOT NULL,
	id_cancha int NOT NULL,
	CONSTRAINT fk_usuario FOREIGN KEY (usuario_id) REFERENCES usuario (usuario_id) ON DELETE CASCADE,
	fecha DATE NOT NULL,
	horainicio TIME NOT NULL,
    horafin TIME NOT NULL,
    estado VARCHAR(50) CHECK(estado IN ('PAGADO', 'PENDIENTE') ),
    CONSTRAINT fk_cancha FOREIGN KEY (id_cancha)REFERENCES cancha (id_cancha) ON DELETE CASCADE
);

-- Sexta tabla a crear
CREATE TABLE pago (
    id_pago SERIAL PRIMARY KEY,
    reserva_id INT NOT NULL,
    fecha DATE NOT NULL,
    monto NUMERIC(10, 2),
    CONSTRAINT fk_reserva_pago FOREIGN KEY (reserva_id)REFERENCES reserva(reserva_id)
);

SELECT R.usuario_id, P.fecha , P.monto, R.id_cancha
FROM reserva r
JOIN pago p ON r.reserva_id = p.reserva_id
WHERE r.estado = 'PAGADO'

SELECT COUNT(usuario_id) FROM usuario WHERE documento = '26991264';