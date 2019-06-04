using Shopping.ListaZakupow;
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
	public partial class Lista : ContentPage
	{
		public Lista ()
		{
			InitializeComponent ();
		}

        private void BasicList_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BasicList());
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ShowList());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListWithCost());
        }
    }
}