using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAdmin.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class clientes : ContentPage
    {
        public clientes()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddCliente());
        }
    }
}