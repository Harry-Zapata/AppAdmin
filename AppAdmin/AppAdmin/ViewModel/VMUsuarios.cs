using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppAdmin.Conexion;
using AppAdmin.Datos;
using AppAdmin.Modelo;
using AppAdmin.Vistas;
using Xamarin.Forms;

namespace AppAdmin.ViewModel
{
    public class VMUsuarios : BaseViewModel
    {
        #region VARIABLES
        public string apellido;
        public string dni;
        public string direccion;
        public string nombre;
        public string telefono;
        #endregion

        #region OBJETOS
        public string txtApellido 
        {
            get { return apellido; }
            set { SetValue(ref apellido, value); } 
        }
        public string txtDni
        {
            get { return dni; }
            set { SetValue(ref dni, value); }
        }
        public string txtDireccion
        {
            get { return direccion; }
            set { SetValue(ref direccion, value); }
        }
        public string txtNombre
        {
            get { return nombre; }
            set { SetValue(ref nombre, value); }
        }
        public string txtTelefono
        {
            get { return telefono; }
            set { SetValue(ref telefono, value); }
        }
        #endregion

        #region PROCESOS
        private async Task insertarUsuarios()
        {
            var funcion = new Dusuario();
            var campos = new MUsuarios();
            campos.Apellido = txtApellido;
            campos.Nombre = txtNombre;
            campos.Dni = txtDni;
            campos.Direccion = txtDireccion;
            campos.Telefono = txtTelefono;

            var estadoFuncion = await funcion.InsertarUsuario(campos);
            if (estadoFuncion)
            {
                await DisplayAlert("Registro", "Se registro el usuario correctamente","OK");
            }
        }
        #endregion

        #region COMANDOS
        //public ICommand InsertarComand => new Command(async ()=> await insertarUsuarios());
        public Command InsertarComando { get; }
        #endregion

        #region CONSTRUCTOR
        public VMUsuarios(INavigation navigation)
        {
            Navigation = navigation;
            InsertarComando = new Command(async () => await insertarUsuarios());
        }
        #endregion
    }
}
