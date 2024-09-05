using AppAdmin.Datos;
using AppAdmin.Modelo;
using AppAdmin.Vistas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace AppAdmin.ViewModel
{
    public class VMLogin : BaseViewModel
    {
        #region VARIABLES
        public string dni;
        public List<MUsuarios> listaUsuarios = new List<MUsuarios>();
        #endregion

        #region OBJETOS
        public string txtDni
        {
            get { return dni; }
            set { SetValue(ref dni, value); }
        }

        public List<MUsuarios> lstUsuarios
        {
            get { return listaUsuarios; }
            set { SetValue(ref listaUsuarios, value); }
        }

        #endregion

        #region PROCESOS
        private async Task ValidarUsuario()
        {
            var funcion = new Dusuario();
            var campos = new MUsuarios();
            campos.Dni = txtDni;
            lstUsuarios = await funcion.ValidarLogin(campos);

            if (lstUsuarios.Count > 0)
            {
                await Navigation.PushAsync(new menu(lstUsuarios));
            }
            else
            {
                await DisplayAlert("Error de Inicio","Usuario no Registrado","ok");
            }

        }
        #endregion

        #region COMANDOS
        public Command ValidarComando { get; }
        #endregion

        #region CONSTRUCTOR
        public VMLogin(INavigation navigation)
        {
            Navigation = navigation;
            ValidarComando = new Command(async () => await ValidarUsuario());
        }
        #endregion
    }
}
