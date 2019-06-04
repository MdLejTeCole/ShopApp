using Shopping.ListaZakupow;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shopping
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowList : ContentPage
	{

        public ShowList()
        {
            InitializeComponent();
            DateTime date = new DateTime();
            List<ListToOpen> myList = new List<ListToOpen>
            {
            };
            SqlConnection sqlConnection = new SqlConnection("Server=tcp:mdlejtecole.database.windows.net,1433;Initial Catalog=ShopApp2;Persist Security Info=False;" +
            "User ID=MDlejtecole;Password=muza!345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(DISTINCT DataListy) from ListaZakupow", sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int a = reader.GetInt32(0);
            reader.Close();
            for (int i = 0; i < a; i++)
            {
                int b = i + 1;
                cmd = new SqlCommand("select top 1 * from(select DISTINCT top " +b+ " DataListy from ListaZakupow order by DataListy asc) a order by DataListy desc", sqlConnection);
                reader = cmd.ExecuteReader();
                reader.Read();
                myList.Add(new ListToOpen() { Data = reader.GetDateTime(0).ToString(), Name = "Lista nr: ", Count = i + 1 });
                reader.Close();
            }
            listView.ItemsSource = myList;
            a = 0;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listS = e.SelectedItem as ListToOpen;
            Navigation.PushAsync(new SelectedList(listS.Data));
        }

    }
}