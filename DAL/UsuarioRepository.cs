using ENTITY;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioRepository : BaseDatos, IRepository<Usuario>
    {
        public List<Usuario> Consultar()
        {
            string sentencia = "select * from postgres.\"CanchasDB\".usuario";

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

        private Usuario Mappear(NpgsqlDataReader reader)
        {
            return new Usuario
            {
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
                    INSERT INTO postgres.""CanchasDB"".usuario (documento, nombre, apellido, telefono) 
                    VALUES (@documento, @nombre, @apellido, @telefono) 
                    RETURNING usuario_id";

            using (NpgsqlCommand cmd = new NpgsqlCommand(sentencia, conexion))
            {
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
