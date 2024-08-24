using System;
using System.Collections.Generic;
using System.Text;
using AppAdmin.Modelo;
using AppAdmin.Conexion;
using Firebase.Database;
using System.Threading.Tasks;
using Firebase.Database.Query;
using System.Linq;

namespace AppAdmin.Datos
{
    public class Dusuario
    {
        public async Task<bool> InsertarUsuario(MUsuarios usuarios)
        {
            await ConexionFirebase.ClientFirebase
                .Child("Usuarios").PostAsync(new MUsuarios()
                {
                    Apellido = usuarios.Apellido,
                    Dni = usuarios.Dni,
                    Direccion = usuarios.Direccion,
                    Nombre = usuarios.Nombre,
                    Telefono = usuarios.Telefono,
                });
            return true;
        }



        public async Task<List<MUsuarios>> MostrarUsuarios()
        {
            return (await ConexionFirebase.ClientFirebase
                .Child("Usuarios")
                .OnceAsync<MUsuarios>()).Select(item => new MUsuarios
                {
                    Apellido = item.Object.Apellido,
                    Dni = item.Object.Dni,
                    Direccion = item.Object.Direccion,
                    Nombre = item.Object.Nombre,
                    Telefono = item.Object.Telefono,
                }).ToList();
        }

        public async Task<List<MUsuarios>> MostrarUsuarioById(MUsuarios usuario)
        {
            return(
                await ConexionFirebase.ClientFirebase
                .Child("Usuarios").
                OnceAsync<MUsuarios>())
                .Where(a=>a.Key == usuario.idUsuario).Select(item=> new MUsuarios
                {
                    Apellido = item.Object.Apellido,
                    Dni = item.Object.Dni,
                    Direccion = item.Object.Direccion,
                    Nombre = item.Object.Nombre,
                    Telefono = item.Object.Telefono,
                    idUsuario = item.Key
                }).ToList();
        }
    }
}
