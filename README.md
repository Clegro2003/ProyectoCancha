# 🏟️ Proyecto de Aula P3 - Sistema de Reservas de Canchas Deportivas vía Telegram

Este proyecto es una solución integrada que permite a los usuarios **registrarse**, **reservar canchas**, **cancelar reservas** y **realizar pagos** directamente desde Telegram. A su vez, ofrece un **panel administrativo con reportes gráficos** sobre el uso de las canchas.

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

4. **Ajusta la cadena de conexión**
   En la clase `BaseDatos.cs` asegúrate de tener:

   ```csharp
   string cadenaConexion = "Host=localhost;Port=5432;Username=postgres;Password=tu_clave;Database=nombre_bd";
   ```

5. **Coloca el archivo QR** (para pagos):

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

## 💻 Módulo Administrativo (WinForms)

* **Visualización de reservas** por día, semana, mes o últimos 30 días.
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
> Grupo 02 – Estructuras de Datos
> 🗕 Junio 2025

---

## 📋 Licencia

Este proyecto es parte de una entrega académica. Uso con fines educativos únicamente.
