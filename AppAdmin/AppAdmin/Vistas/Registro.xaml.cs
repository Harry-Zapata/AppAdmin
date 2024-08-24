using AppAdmin.ViewModel;
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
    public partial class Registro : ContentPage
    {
        public Registro()
        {
            InitializeComponent();
            BindingContext = new VMUsuarios(Navigation);
        }

        private async void Ir_A_Login(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}