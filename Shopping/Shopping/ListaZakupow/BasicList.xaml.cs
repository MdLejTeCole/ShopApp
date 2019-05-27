using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shopping.ListaZakupow
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BasicList : ContentPage
	{
		public BasicList ()
		{
			InitializeComponent ();
            listView.ItemsSource = new List<Categories>
            {
                new Categories {Categoria="Strona główna", Status=false},
                new Categories {Categoria="Promocje", Status=false},              
            };
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}