using AppAdmin.Datos;
using AppAdmin.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace AppAdmin.ViewModel
{
    public class VMInicioClientes : BaseViewModel
    {
        #region Variables
        public List<MClientes> lclientes;
        #endregion

        #region Objetos
        public List<MClientes> ListaClientes
        {
            get { return lclientes; }
            set { SetValue(ref lclientes, value); }
        }
        #endregion

        #region Procesos
        public async void ObtenerDatosClientes()
        {
            var funcion = new Dclientes();
            lclientes = await funcion.ListarClientes();
        }
        #endregion

        #region Comandos
        #endregion

        #region Constructor
        public VMInicioClientes(INavigation navigation)
        {
            Navigation = navigation;
            ObtenerDatosClientes();
        }
        #endregion
    }
}
