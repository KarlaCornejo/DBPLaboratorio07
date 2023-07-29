 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Laboratorio6
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        IList<String> getCiudades();
        [OperationContract]
        void GuardarInformacion(string nombre, string apellidos, string sexo, string correo, string direccion, string ciudad, string descripcion);

        [OperationContract]
        IList<String> GetCiudades_SQL();


        [OperationContract]
        bool GuardarInformacionSimpleSQL(string nombre, string apellidos, string sexo, string correo, string direccion, int codeCiudad, string descripcion);
        
        [OperationContract]
        bool GuardarInformacionVerificandoSQL(string nombre, string apellidos, string sexo, string email, string direccion, int codeCiudad, string descripcion);
    }
}
