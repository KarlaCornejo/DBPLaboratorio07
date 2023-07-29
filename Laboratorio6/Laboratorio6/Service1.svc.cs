using ProyectoDatos;
using ProyectoDatos.Dao;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Web;

namespace Laboratorio6
{
    public class Service1 : IService1
    {
        public IList<string> GetCiudades_SQL()
        {
            Ciudad c = new Ciudad();
            return c.Query();
        }

        public IList<string> getCiudades()
        {
            IList<string> ciudades = new List<string>();
            ciudades.Add("Arequipa");
            ciudades.Add("Lima");
            ciudades.Add("Tacna");
            return ciudades;
        }

        public void GuardarInformacion(string nombre, string apellidos, string sexo, string correo, string direccion, string ciudad, string descripcion)
        {
            string rutaArchivo = HttpContext.Current.Server.MapPath("~/Informacion.txt");

            using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
            {
                writer.WriteLine($"Nombre: {nombre}");
                writer.WriteLine($"Apellidos: {apellidos}");
                writer.WriteLine($"Sexo: {sexo}");
                writer.WriteLine($"Correo: {correo}");
                writer.WriteLine($"Dirección: {direccion}");
                writer.WriteLine($"Ciudad: {ciudad}");
                writer.WriteLine($"Descripción: {descripcion}");
                writer.WriteLine("----------------------------------");
            }
        }

        public bool GuardarInformacionSimpleSQL(string nombre, string apellidos, string sexo, string email, string direccion, int codeCiudad, string descripcion)
        {
            DatoAlumnos data = new DatoAlumnos();
            try
            {
                data.InsertarRegistro(nombre, apellidos, email, sexo, codeCiudad, descripcion);
                return true;
            }
            catch (Exception ex)
            {
                // Registrar la excepción para trazabilidad o análisis.
                // ...

                // Lanzar una excepción personalizada utilizando el contrato de servicio.
                return false;
            }
        }

        public bool GuardarInformacionVerificandoSQL(string nombre, string apellidos, string sexo, string email, string direccion, int codeCiudad, string descripcion)
        {
            DatoAlumnos data = new DatoAlumnos();
            if (data.RegistroExiste(nombre,apellidos))
            {
                return false;
            }

            try
            {
                data.InsertarRegistro(nombre, apellidos, email, sexo, codeCiudad, descripcion);
                return true;
            }
            catch (Exception ex)
            {
                // Registrar la excepción para trazabilidad o análisis.
                // ...

                // Lanzar una excepción personalizada utilizando el contrato de servicio.
                return false;
            }
        }
    }
}
