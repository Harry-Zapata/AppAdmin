using AppAdmin.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppAdmin.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppAdmin.Vistas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class menu : ContentPage
	{
		public menu (List<MUsuarios> mUsuarios)
		{
			InitializeComponent ();
			BindingContext = new VMInicio(Navigation, mUsuarios);
		}
	}
}