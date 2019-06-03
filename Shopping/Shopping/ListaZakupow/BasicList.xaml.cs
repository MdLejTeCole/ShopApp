using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            List<Categories> cat = new List<Categories>();
 
            SqlConnection sqlConnection = new SqlConnection("Server=tcp:mdlejtecole.database.windows.net,1433;Initial Catalog=ShopApp1;Persist Security Info=False;" +
               "User ID=MDlejtecole;Password=muza!345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();
            bool exist = true;
           
            for (int i = 1; i < 18; i++)
            {

            
                SqlCommand cmd = new SqlCommand("SELECT PodKategoria FROM Kategorie WHERE IdKategoria =" + i, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                cat.Add(new Categories() { Categoria = reader.GetString(0), Status = false });                               
                reader.Close();

            }
            listView.ItemsSource = cat;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}