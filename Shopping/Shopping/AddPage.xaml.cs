using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shopping
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPage : ContentPage
	{
		public AddPage ()
		{
            //if (contact == null)
            //    throw new ArgumentException();

            //BindingContext = contact;
            InitializeComponent ();
		}
	}
}