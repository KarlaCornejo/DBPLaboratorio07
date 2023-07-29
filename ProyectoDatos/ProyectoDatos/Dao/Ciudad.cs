using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ProyectoDatos.Dao
{
    public class Ciudad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public IList<string> Query()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DBKarla;Integrated Security=True;Connect Timeout=30";
            string query = "SELECT Ciudad FROM [dbo].Ciudad;";
            Console.WriteLine(query);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<string> ciudades = new List<string>();
                        while (reader.Read())
                        {
                            string nombreCiudad = reader.GetString(0);
                            Console.WriteLine(nombreCiudad);
                            ciudades.Add(nombreCiudad);
                        }

                        return ciudades;
                    }
                }
            }
        }
    }
}

