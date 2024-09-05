using AppAdmin.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppAdmin.ViewModel
{
    public class VMInicio : BaseViewModel
    {
        #region Variables
        public string nombre;
        public string apellido;
        public string dni;
        public List<MUsuarios>  lusuarios = new List<MUsuarios>();
        #endregion

        #region Objetos
        public string lblNombre
        {
            get { return nombre; }
            set { SetValue(ref nombre, value); }
        }
        public string lblApellido
        {
            get { return apellido; }
            set { SetValue(ref apellido, value); }
        }
        public string lblDni
        {
            get { return dni; }
            set { SetValue(ref dni, value); }
        }
        public List<MUsuarios> ListaUsuarios
        {
            get { return lusuarios; }
            set { SetValue(ref lusuarios, value); }
        }


        #endregion

        #region Procesos
        public void ObtenerDatosUsuario()
        {
            var datos = ListaUsuarios.FirstOrDefault();
            lblNombre = datos.Nombre;
            lblApellido = datos.Apellido;
            lblDni = datos.Dni;
        }
        #endregion

        #region Comandos
        #endregion

        #region Constructor
        public VMInicio(INavigation navigation, List<MUsuarios> mUsuarios)
        {
            Navigation = navigation;
            ListaUsuarios = mUsuarios;
            ObtenerDatosUsuario();
        }
        #endregion
    }
}
