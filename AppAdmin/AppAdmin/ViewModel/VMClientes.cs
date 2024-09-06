using AppAdmin.Datos;
using AppAdmin.Modelo;
using AppAdmin.Vistas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppAdmin.ViewModel
{
    public class VMClientes : BaseViewModel
    {
        #region Variables
        public string direccion;
        public string dni;
        public string email;
        public string estado;
        public string fechaNacimiento;
        public string fechaRegistro;
        public string nombre;
        public string telefono;
        #endregion

        #region Objetos
        public string txtDireccion
        {
            get { return direccion; }
            set { SetValue(ref direccion, value); }
        }
         public string txtDni
        {
            get { return dni; }
            set { SetValue(ref dni, value); }
        }
         public string txtEmail
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }
         public string txtEstado
        {
            get { return estado; }
            set { SetValue(ref estado, value); }
        }
         public string txtFechaNacimiento
        {
            get { return fechaNacimiento; }
            set { SetValue(ref fechaNacimiento, value); }
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

        #region Procesos
        private async Task insertarClientes()
        {
            if (string.IsNullOrWhiteSpace(txtDireccion) ||
                string.IsNullOrWhiteSpace(txtDni) ||
                string.IsNullOrWhiteSpace(txtEmail) ||
                string.IsNullOrWhiteSpace(txtEstado) ||
                string.IsNullOrWhiteSpace(txtFechaNacimiento) ||
                string.IsNullOrWhiteSpace(txtTelefono) ||
                string.IsNullOrWhiteSpace(txtNombre))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe llenar todos los campos.", "OK");
                return;
            }
            var funcion = new Dclientes();
            var campos = new MClientes
            {
                Direccion = txtDireccion,
                Dni = txtDni,
                Email = txtEmail,
                Estado = txtEstado,
                FechaNacimineto = txtFechaNacimiento,
                FechaRegistro = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow,TimeZoneInfo.FindSystemTimeZoneById("EST")).ToString("dd/MM/yyyy HH:mm:ss"),
                Nombre = txtNombre,
                Telefono = txtTelefono,
            };

            var estadoFuncion = await funcion.InsertarCliente(campos);
            if (!estadoFuncion)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El DNI ya está ingresado.", "OK");
                return;
            }

            await Application.Current.MainPage.DisplayAlert("Registro", "Se registró el cliente correctamente", "OK");

            // Limpiar los campos del formulario
            txtDireccion = string.Empty;
            txtDni = string.Empty;
            txtEmail = string.Empty;
            txtEstado = string.Empty;
            txtFechaNacimiento = string.Empty;
            txtNombre = string.Empty;
            txtTelefono = string.Empty;

            // Navegar a la página de inicio de sesión
            await Navigation.PushAsync(new clientes());
        }
        #endregion

        #region Comandos
        public Command InsertarClienteComando { get; }
        #endregion

        #region Constructor
        public VMClientes(INavigation navigation)
        {
            Navigation = navigation;
            InsertarClienteComando = new Command(async () => await insertarClientes());
        }
        #endregion
    }
}
