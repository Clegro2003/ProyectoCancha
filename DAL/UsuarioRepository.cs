using ENTITY;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    public class UsuarioRepository : BaseDatos
    {
        public List<Usuario> Consultar()
        {
            string sentencia = "SELECT usuario_id,chatid, documento,nombre,apellido,telefono FROM postgres.\"CanchasDB\".usuario";

            NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conexion);
            AbrirConexion();
            NpgsqlDataReader reader = cmd.ExecuteReader();

            List<Usuario> lista = new List<Usuario>();
            while (reader.Read())
            {
                lista.Add(Mappear(reader));
            }
            CerrarConexion();
            return lista;
        }

        public bool ConsultarUsuarioPorID(string Id)
        {
            bool existe = false;
            string sentencia = @"SELECT COUNT(usuario_id) FROM ""CanchasDB"".usuario WHERE documento = @usuario_id";
            NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conexion);
            cmd.Parameters.AddWithValue("@usuario_id", Id);
            AbrirConexion();
            NpgsqlDataReader reader = cmd.ExecuteReader();
            cmd.Parameters.AddWithValue("@documento", Id);
            AbrirConexion();
            var resultado = cmd.ExecuteScalar();

            CerrarConexion();

            if (resultado != null && Convert.ToInt32(resultado) > 0)
            {
                existe = true;
            }

            return existe;
        }

        public Usuario ConsultarPorChatID(string chatId)
        {
            string sentencia = "SELECT usuario_id,chatid,documento,nombre,apellido,telefono " +
                               "FROM postgres.\"CanchasDB\".usuario " +
                               "WHERE chatid = @chatid";

            NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conexion);
            cmd.Parameters.AddWithValue("@chatid", chatId);
            AbrirConexion();
            NpgsqlDataReader reader = cmd.ExecuteReader();

            Usuario user = null;
            while (reader.Read())
            {
                user = Mappear(reader);
            }
            CerrarConexion();
            return user;
        }

        private Usuario Mappear(NpgsqlDataReader reader)
        {
            return new Usuario
            {
                Usuario_id = reader.GetInt32(reader.GetOrdinal("usuario_id")),
                ChatID = reader.GetString(reader.GetOrdinal("chatid")),
                Documento = reader.GetString(reader.GetOrdinal("documento")),
                Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                Apellido = reader.GetString(reader.GetOrdinal("apellido")),
                Telefono = reader.GetString(reader.GetOrdinal("telefono"))
            };
        }

        public string Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public string Guardar(Usuario entity)
        {
            if (entity == null || string.IsNullOrWhiteSpace(entity.Documento) || string.IsNullOrWhiteSpace(entity.Nombre) || string.IsNullOrWhiteSpace(entity.Telefono))
                return "Datos inválidos";

            string sentencia = @"
                    INSERT INTO postgres.""CanchasDB"".usuario (chatid, documento, nombre, apellido, telefono) 
                    VALUES (@chatid, @documento, @nombre, @apellido, @telefono) 
                    RETURNING usuario_id";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conexion))
            {
                cmd.Parameters.AddWithValue("@chatid", entity.ChatID);
                cmd.Parameters.AddWithValue("@documento", entity.Documento);
                cmd.Parameters.AddWithValue("@nombre", entity.Nombre);
                cmd.Parameters.AddWithValue("@apellido", entity.Apellido ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@telefono", entity.Telefono);

                try
                {
                    AbrirConexion();
                    object result = cmd.ExecuteScalar(); // Obtiene el ID insertado
                    //return result != null ? $"Usuario insertado correctamente con ID {result}" : "No se ha insertado el usuario.";
                    return result != null ? $"Okey... Perfecto" : "No se ha insertado el usuario.";
                }
                catch (PostgresException ex)
                {
                    return $"Error de PostgreSQL: {ex.Message}";
                }
                catch (Exception ex)
                {
                    return $"Error general: {ex.Message}";
                }
                finally
                {
                    CerrarConexion();
                }
            }
        }


        public string Modificar(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
