# 🏟️ Proyecto de Aula P3 - Sistema de Reservas de Canchas Deportivas vía Telegram

Este proyecto es una solución integrada que permite a los usuarios **registrarse**, **reservar canchas**, **cancelar reservas** y **realizar pagos** directamente desde Telegram. A su vez, ofrece un **panel administrativo con reportes gráficos** sobre el uso de las canchas. Este proyecto representa una solución completa e innovadora para la gestión de reservas deportivas, combinando la accesibilidad de Telegram con el poder visual de un panel administrativo gráfico. Está diseñado para facilitar al máximo la experiencia del usuario final.
Con esta herramienta, se logra automatizar gran parte del proceso manual de reservas, reducir errores humanos y optimizar el uso de las canchas disponibles. Además, se proporciona una experiencia moderna y amigable tanto para el usuario como para los administradores del sistema.

---

## 🔧 Requisitos del Sistema

### ✅ Software necesario

| Herramienta          | Versión recomendada | Descripción                                      |
| -------------------- | ------------------- | ------------------------------------------------ |
| .NET Framework       | 4.7.2               | Framework para el desarrollo en WinForms         |
| Visual Studio        | 2022+               | IDE para desarrollo de escritorio                |
| Docker Desktop       | 4.38.0              | Usado para levantar la base de datos PostgreSQL  |
| PostgreSQL           | 15+                 | Motor de base de datos                           |
| DBeaver              | 25+                 | Cliente gráfico para gestionar la base de datos  |
| Npgsql (NuGet)       | Última estable      | Conector C# ↔ PostgreSQL                         |
| Telegram.Bot (NuGet) | 18+                 | Librería para interactuar con la API de Telegram |
| FontAwesome.Sharp       | Última estable      | Iconografía moderna para WinForms             |

---

## 📦 Estructura del Proyecto

```
Proyecto_Cancha/
│
├── ENTITY/              # Entidades: Usuario, Reserva, Cancha, TipoCancha
├── DAL/                 # Capa de acceso a datos (PostgreSQL)
├── BLL/                 # Lógica del bot, manejo de acciones y lógica de negocio
├── GUI/                 # Dashboard de reportes en Windows Forms
│   └── Dashboard_Reporte.cs
├── SCRIPTS SQL/         # Scripts de creación de tablas y consultas
├── IMAGENES/            # QR o imágenes utilizadas en el bot
└── README.md            # Este archivo
```

---

## 🛠️ Instalación y Configuración

1. **Clona el repositorio**

   ```bash
   git clone https://github.com/Clegro2003/ProyectoCancha.git
   ```

2. **Restaurar paquetes NuGet**
   Al abrir el `.sln` en Visual Studio, acepta restaurar dependencias.

3. **Configura la base de datos PostgreSQL**

   Ejecuta el siguiente script base:

 Script 001 - Crear la base de datos
``` sql
   DROP DATABASE IF EXISTS CanchasDB;
   CREATE DATABASE CanchasDB;
 ```
  Script 002 - Creacion de tablas
   ```sql
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
   ```
   Script 003 - Insercion de datos
``` sql
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
   (30, 1, '2025-04-10', '08:00', '09:00', 'PAGADO'),
   (30, 2, '2025-04-10', '09:00', '10:00', 'PENDIENTE'),
   (30, 3, '2025-04-10', '10:00', '11:00', 'PAGADO'),
   (30, 4, '2025-04-10', '11:00', '12:00', 'PAGADO');
   
   -- Reservas para el 15 de mayo de 2025
   INSERT INTO reserva (usuario_id, id_cancha, fecha, horainicio, horafin, estado) VALUES
   (30, 1, '2025-05-15', '08:00', '09:00', 'PAGADO'),
   (30, 2, '2025-05-15', '09:00', '10:00', 'PAGADO'),
   (30, 3, '2025-05-15', '10:00', '11:00', 'PENDIENTE'),
   (30, 4, '2025-05-15', '11:00', '12:00', 'PAGADO');
   
   -- 5 reservas para el 03 de junio de 2025
   INSERT INTO reserva (usuario_id, id_cancha, fecha, horainicio, horafin, estado) VALUES
   (30, 2, '2025-06-03', '08:00', '09:00', 'PAGADO'),
   (30, 3, '2025-06-03', '09:00', '10:00', 'PAGADO'),
   (30, 4, '2025-06-03', '10:00', '11:00', 'PENDIENTE'),
   (30, 1, '2025-06-03', '11:00', '12:00', 'PAGADO'),
   (30, 2, '2025-06-03', '12:00', '13:00', 'PAGADO');
   ```

Script 004 - Creacion de función

``` sql 
   CREATE OR REPLACE FUNCTION insertar_pago_automatico()
   RETURNS TRIGGER AS $$
   DECLARE
       precio_cancha numeric(10,2);
   BEGIN
       IF NEW.estado = 'PAGADO' AND OLD.estado IS DISTINCT FROM 'PAGADO' THEN
           SELECT precio INTO precio_cancha
           FROM "CanchasDB".cancha
           WHERE id_cancha = NEW.id_cancha;
   
           INSERT INTO "CanchasDB".pago (reserva_id, fecha, monto)
           VALUES (NEW.reserva_id, CURRENT_DATE, precio_cancha);
       END IF;
   
       RETURN NEW;
   END;
   $$ LANGUAGE plpgsql;
   
   
   CREATE TRIGGER trg_insertar_pago
   AFTER UPDATE ON "CanchasDB".reserva
   FOR EACH ROW
   EXECUTE FUNCTION insertar_pago_automatico();
   
   DROP FUNCTION insertar_pago_automatico;
   DROP TRIGGER IF EXISTS trg_insertar_pago ON "CanchasDB".reserva;
   ```


5. **Ajusta la cadena de conexión**
   En la clase `BaseDatos.cs` asegúrate de tener:

   ```csharp
   string cadenaConexion = "Host=localhost;Port=5432;Username=postgres;Password=tu_clave;Database=nombre_bd";
   ```

6. **Coloca el archivo QR** (para pagos):

   ```
   Proyecto_Cancha/IMAGENES/qr-prueba-2.jpg
   ```

---

## 🤖 Funcionalidades del Bot de Telegram

* Registro único por usuario (chat ID y documento).
* Visualización de canchas disponibles por tipo: "CON TECHO" o "SIN TECHO".
* Validación de:

  * Fechas pasadas.
  * Conflictos de horarios.
  * Formatos inválidos.
* Cancelación de reservas activas.
* Realización de pagos con envío de imagen QR.
* Respuesta contextual basada en el estado de conversación del usuario.
---

## Iniciando el Bot

* 1. Registro de usuario y reserva de  cancha.
   Primeramente si el usuaario no esta resgistrado, el bot pide sus datos personales.
   - El documento y telefono del usuario debe contener obligratoriamente 10 caracteres numericos para que sea valido el registro.
   Luego del registro se muestra un mensaje de confirmacion y el bot muesttra 3 botones con las opciones "RESERVAR CANCHA",
   "CANCELAR RESERVA DE CANCHA" Y "REALIZAR PAGO" y dependiendo de la necesidad del usuario solo debera clickar el boton correspondiente.

   ![image](https://github.com/user-attachments/assets/cb7df404-6c63-48d5-9c68-6e882d9e250f)

     [Imagen 1] REGISTRO DE USUARIO

   ![image](https://github.com/user-attachments/assets/f0b909a3-c9e0-475b-8631-ce996dcc0f5a)

  ![image](https://github.com/user-attachments/assets/c35b089f-e525-4ed4-8f3b-41df786726ce)

* 2. Cancelar reserva.
    Al termimnar el proceso de la reserva, pregunta al usuario sobre su nueva accion. Si selecciona cancelar reserva, muestra el id del usuario y una lista con las reservas pendientes.
    Luego solicita al usuario el ID de la reserva a cancelar. Al ingresarla mosstrara el mensaja confirmando la cancelacion de la reserva.

   ![image](https://github.com/user-attachments/assets/cf46ebdf-22e3-42cb-8cc0-f6915612d363)
     
 
* 3. Realizar pago de reserva.
    Al termimnar el proceso de la reserva, pregunta al usuario sobre su nueva accion. Si selecciona realizar pago, muestra el id del usuario y una lista con las reservas pendientes.
    Luego solicita al usuario el ID de la reserva a desea pagar. Al ingresarla el ID muestra una imgen de un qr y el mensaja confirmando el pago.
---

## 💻 Módulo Administrativo (WinForms)
![image](https://github.com/user-attachments/assets/904a5bb4-7e8e-4168-b871-aa8ef7486b68)

* **Visualización de reservas** por día, semana, mes o últimos 30 días. Estan conectado al grafico de pastel, con la tabla de las reservas realizadas, la cantidad de reservas y el total de horas reservadas.
  
* **Gráficos**:
  * Barras por día
  * Barras por hora
  * Pastel por tipo de cancha
    
* **Totales**:
  * Cantidad de reservas
  * Total de horas reservadas

---

## 🧠 Estado de la Conversación del Usuario (Contextos)

Los contextos posibles son:

* `INICIO`
* `RESERVA`
* `CANCELAR`
* `REALIZAR_PAGO`
* `MENU` (inicio del sistema si ya está registrado)

---

## 📌 Consideraciones Técnicas

* Se usa un `Dictionary<string, string> chats` para mantener el estado conversacional por usuario.
* Las reservas están validadas para evitar conflictos de tiempo con otras ya registradas.
* El Dashboard se actualiza automáticamente al ejecutar la app con:

  * Reservas del mes actual
  * Gráfico por hora del día actual

---

## 🚀 Iniciar el Proyecto

Desde `GUI`, ejecuta la `Dashboard_Reporte.cs`. Automáticamente:

* Se activa el bot de Telegram.
* Se carga la interfaz con las estadísticas actuales.

---

## 🤛 Autor

> Carlos Alberto Legro De La Rosa
> Jorge Junior Rometo Montenegro
> Grupo 03 y 05 – Estructuras de Datos
> 🗕 Junio 2025

---

## 📋 Licencia

Este proyecto es parte de una entrega académica. Uso con fines educativos únicamente.
