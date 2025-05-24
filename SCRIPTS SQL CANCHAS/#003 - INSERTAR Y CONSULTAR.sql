INSERT INTO usuario (documento, nombre, apellido, telefono) VALUES
('1029384756', 'Carlos', 'Pérez', '3001234567'),
('2049583746', 'Laura', 'Gómez', '3123456789'),
('3948571620', 'Andrés', 'Martínez', '3012345678'),
('7583947261', 'Tatiana', 'Rodríguez', '3112233445'),
('1938472650', 'Felipe', 'García', '3209988776'),
('8473629103', 'Mariana', 'López', '3105566778'),
('2837461920', 'Juan', 'Torres', '3133344556'),
('5647382910', 'Camila', 'Sánchez', '3121122334'),
('1234567890', 'Diana', 'Moreno', '3007788990'),
('9081726354', 'David', 'Ruiz', '3045566443');

INSERT INTO tipocancha(id_tipocancha, nombre_cancha) VALUES
(1, 'CON TECHO'),
(2, 'SIN TECHO');

INSERT INTO cancha (id_cancha , id_tipocancha, estado, precio ) VALUES
(3, 1, 'DISPONIBLE', 20000),
(4, 2, 'OCUPADO', 25000),
(6, 2, 'DISPONIBLE', 30000),
(7, 1, 'OCUPADO', 22000),
(8, 2, 'DISPONIBLE', 28000),
(9, 1, 'OCUPADO', 21000),
(10, 2, 'OCUPADO', 27000);

select documento,nombre from postgres."CanchasDB".usuario

SELECT * FROM postgres."CanchasDB".tipocancha

select * from reserva

SELECT id_cancha,estado  FROM cancha 