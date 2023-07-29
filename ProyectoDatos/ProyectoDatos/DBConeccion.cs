using ProyectoDatos.Dao;
using System.Collections.Generic;
using System;

namespace ProyectoDatos
{
    class DBConeccion
    {
        public static void Main(String[] args)
        {
            DBConeccion conn = new DBConeccion();
            conn.query();
            DatoAlumnos program = new DatoAlumnos();
            program.InsertarRegistro("Karla", "López", "cornejo","Femenino",2,"HolaMundo");
        }

        private void query()
        {
            Ciudad c = new Ciudad();
            IList<string> list = c.Query();
            if (list == null)
            {
                Console.WriteLine("No data");
                return;
            }

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
