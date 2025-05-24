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

-- Tercera tabla a crear
CREATE TABLE metodopago (
    id_metodopago SERIAL PRIMARY KEY,
    nombre_metodopago VARCHAR(50) NOT NULL
);

-- cuarta tabla a crear
CREATE TABLE cancha (
    id_cancha SERIAL PRIMARY KEY,
    id_tipocancha INT NOT NULL,
    estado VARCHAR(20) CHECK (estado IN ('DISPONIBLE', 'OCUPADO')),
    precio numeric(10, 2),
    CONSTRAINT fk_tipo_cancha FOREIGN KEY (id_tipocancha) REFERENCES tipocancha(id_tipocancha) ON DELETE CASCADE
);

-- Quinta tabla a crear
CREATE TABLE reserva(
	reserva_id SERIAL PRIMARY KEY,
	usuario_id INT NOT NULL,
	id_cancha int NOT NULL,
	CONSTRAINT fk_usuario FOREIGN KEY (usuario_id) REFERENCES usuario (usuario_id) ON DELETE CASCADE,
	fecha DATE NOT NULL,
	horainicio VARCHAR(20) NOT NULL,
    horafin VARCHAR(20) NOT NULL,
    estado VARCHAR(50) CHECK(estado IN ('PAGADO', 'PENDIENTE') ),
    CONSTRAINT fk_cancha FOREIGN KEY (id_cancha)REFERENCES cancha (id_cancha) ON DELETE CASCADE
);

-- Sexta tabla a crear
CREATE TABLE pago (
    id_pago SERIAL PRIMARY KEY,
    reserva_id INT NOT NULL,
    id_metodopago INT NOT NULL,
    fecha DATE NOT NULL,
    estado VARCHAR(20),
    monto NUMERIC(10, 2),
      CONSTRAINT fk_reserva_pago FOREIGN KEY (reserva_id)REFERENCES reserva(reserva_id),
      CONSTRAINT fk_metodo_pago FOREIGN KEY (id_metodopago) REFERENCES metodoPago(id_metodopago)
);



