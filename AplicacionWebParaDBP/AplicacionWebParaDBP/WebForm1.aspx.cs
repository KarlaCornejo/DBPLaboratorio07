//using AplicacionWebParaDBP.ServiceReference1;
using AplicacionWebParaDBP.ServiciosLaboratorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicacionWebParaDBP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                addDropDownCiudadItem();
                // Lógica para cargar los datos iniciales, si es necesario
            }
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            // Lógica para manejar el evento ButtonEnviar_Click
            string nombre = this.nombre.Text;
            string apellidos = this.apellidos.Text;
            string sexo = string.Empty;
            if (this.sexo.SelectedValue == "M")
            {
                sexo = "Masculino";
            }
            else if (this.sexo.SelectedValue == "F")
            {
                sexo = "Femenino";
            }
            string correo = this.correo.Text;
            string direccion = this.direccion.Text;
            int ciudad = this.ciudadDropdown.SelectedIndex;
            string ciudad2 = this.ciudadDropdown.SelectedValue;
            string descripcion = this.descripcion.Text;

            // Mostrar los valores recibidos en el contenedor
            this.lblNombre.InnerText = nombre;
            this.lblApellidos.InnerText = apellidos;
            this.lblSexo.InnerText = sexo;
            this.lblCorreo.InnerText = correo;
            this.lblDireccion.InnerText = direccion;
            this.lblCiudad.InnerText = ciudad2;
            this.lblDescripcion.InnerText = descripcion;

            // Mostrar el contenedor con los valores recibidos
            this.resultContainer.Visible = true;

            // Llamar a la función para guardar la información
            if (GuardarInformacion(nombre, apellidos, sexo, correo, direccion, ciudad, descripcion))
            {
                // Si el registro es exitoso, muestra la alerta de "correcto"
                string script = "mostrarAlerta(true);";
                ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", script, true);
                
            }
            else
            {
                // Si ocurre un error al guardar, muestra la alerta de "error"
                string script = "mostrarAlerta(false);";
                ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", script, true);
            }
            ;

            // Limpiar los campos del formulario
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            this.nombre.Text = string.Empty;
            this.apellidos.Text = string.Empty;
            this.sexo.SelectedValue = string.Empty;
            this.correo.Text = string.Empty;
            this.direccion.Text = string.Empty;
            this.descripcion.Text = string.Empty;
        }

        private bool GuardarInformacion(string nombre, string apellidos, string sexo, string correo, string direccion, int ciudad, string descripcion)
        {
            // Crear el cliente del servicio
            Service1Client client = new Service1Client();

            try
            {
                // Llamar al método del servicio para guardar la información
                if (client.GuardarInformacionVerificandoSQL(nombre, apellidos, sexo, correo, direccion, ciudad, descripcion))
                {
                    return true;
                }
                else { 
                    return false; 
                }

            }
            finally
            {
                // Cerrar el cliente del servicio en caso de excepción
                if (client.State == System.ServiceModel.CommunicationState.Faulted)
                {
                    client.Abort();
                }
                else
                {
                    client.Close();
                }
            }
        }

        private String[] serviceCall()
        {
            Service1Client client = new Service1Client();
            String[] ciudades = client.GetCiudades_SQL();

            return ciudades;

        }

        protected void addDropDownCiudadItem()
        {
            String[] ciudades = serviceCall();

            Array.Sort(ciudades);
            ciudadDropdown.Items.Add("Selecciona una opcion");

            for (int i = 0; i < ciudades.Length; i++)
            {
                string s = ciudades[i];
                ciudadDropdown.Items.Add(s);
            }
        }



    }
}
