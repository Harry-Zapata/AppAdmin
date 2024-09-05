using AppAdmin.Conexion;
using AppAdmin.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using AppAdmin.ViewModel;

namespace AppAdmin.Datos
{
    public class Dclientes
    {
        public async Task<bool> InsertarCliente(MClientes clientes)
        {
            var clientesExistentes = await ConexionFirebase.ClientFirebase
                .Child("Clientes")
            .OrderBy("Dni")
                .EqualTo(clientes.Dni)
                .OnceAsync<MClientes>();

            if (clientesExistentes.Any())
            {
                return false; 
            }

            await ConexionFirebase.ClientFirebase
                .Child("Clientes")
                .PostAsync(new MClientes()
                {
                    Direccion = clientes.Direccion,
                    Dni = clientes.Dni, 
                    Email = clientes.Email,
                    Estado = clientes.Estado,
                    FechaNacimineto = clientes.FechaNacimineto,
                    FechaRegistro = clientes.FechaRegistro,
                    Nombre = clientes.Nombre,
                    Telefono = clientes.Telefono,
                });
            return true;
        }

    }
}
