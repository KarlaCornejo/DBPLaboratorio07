using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDatos.Dao
{
    public class DatoAlumnos
    {
        public void InsertarRegistro(string nombre, string apellidos, string email, string sexo, int codeCiudad, string requerimiento)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DBKarla;Integrated Security=True;Connect Timeout=30";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Sentencia SQL para la inserción
                    //string sqlInsert = "INSERT INTO [dbo].[DatosAlumnos] (Nombre, Apellidos, CodeCiudad) VALUES (@Nombre, @Apellido, @CodeCiudad)";
                    string query = "INSERT INTO [dbo].[DatosAlumnos] ( Nombre, Apellidos, Email, Sexo, CodeCiudad, Descripcion) " +
                                   "VALUES ( @Nombre, @Apellidos, @Email, @Sexo, @CodeCiudad, @Requerimiento)";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Sexo", sexo);
                        cmd.Parameters.AddWithValue("@CodeCiudad", codeCiudad);
                        cmd.Parameters.AddWithValue("@Requerimiento", requerimiento);

                        cmd.ExecuteNonQuery();
                    }
                }

                Console.WriteLine("Inserción exitosa.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al insertar el registro: " + ex.Message);
            }
        }

        public bool RegistroExiste(string nombre, string apellidos)
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DBKarla;Integrated Security=True;Connect Timeout=30";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM [dbo].[DatosAlumnos] WHERE Nombre = @Nombre AND Apellidos = @Apellidos";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nombre);
                        cmd.Parameters.AddWithValue("@Apellidos", apellidos);

                        int count = (int)cmd.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar el error según tus necesidades
                throw ex;
            }
        }
    }
}
