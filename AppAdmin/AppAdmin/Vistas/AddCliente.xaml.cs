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
    public partial class AddCliente : ContentPage
    {
        public AddCliente()
        {
            InitializeComponent();
            BindingContext = new VMClientes(Navigation);
        }
    }
}