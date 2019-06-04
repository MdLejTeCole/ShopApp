using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shopping.ListaZakupow
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SelectedList : ContentPage
	{
        ObservableCollection<Categories> cat = new ObservableCollection<Categories>();
        public SelectedList(string date)
		{
         
            InitializeComponent ();
            string date1 = date.Remove(10);
            string date2 = date1.Remove(0, 6) + "-";
            date1 = date.Remove(5);
            date2 += date1.Remove(0, 3) + "-";
            date1 = date.Remove(2);
            date2 += date1;
            SqlConnection sqlConnection = new SqlConnection("Server=tcp:mdlejtecole.database.windows.net,1433;Initial Catalog=ShopApp2;Persist Security Info=False;" +
            "User ID=MDlejtecole;Password=muza!345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("select COUNT(DISTINCT IdKategoria) from ListaZakupow Where DataListy LIKE '" + date2 + "%'", sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int a = reader.GetInt32(0);
            reader.Close();
            for (int i = 0; i < a; i++)
            {
                int b = a-i;
                cmd = new SqlCommand("select top 1 * from( select DISTINCT top " +b+ " IdKategoria from ListaZakupow where DataListy LIKE '" +
                    date2 + "%' order by IdKategoria asc) a order by IdKategoria desc", sqlConnection);
                
                reader = cmd.ExecuteReader();
                reader.Read();
                int c = reader.GetInt32(0);
                reader.Close();
                cmd = new SqlCommand("select PodKategoria from Kategorie where IdKategoria = " + c, sqlConnection);
                reader = cmd.ExecuteReader();
                reader.Read();
                cat.Add(new Categories() { Categoria = reader.GetString(0), Grafic = "https://st2.depositphotos.com/7107694/10595/v/950/depositphotos_105958650-stock-illustration-ok-flat-vector-symbol.jpg", Status = false });
                reader.Close();
                reader.Close();
            }
            listView.ItemsSource = cat;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string ok = "https://st2.depositphotos.com/7107694/10605/v/950/depositphotos_106050606-stock-illustration-ok-flat-vector-symbol.jpg";
            string no = "https://st2.depositphotos.com/7107694/10595/v/950/depositphotos_105958650-stock-illustration-ok-flat-vector-symbol.jpg";
            var categorie = e.SelectedItem as Categories;
            if (categorie.Status == false)
            {
                cat.First(d => d.Categoria == categorie.Categoria).Status = true;
                cat.First(d => d.Categoria == categorie.Categoria).Grafic = ok;
            }
            else
            {
                cat.First(d => d.Categoria == categorie.Categoria).Status = false;
                cat.First(d => d.Categoria == categorie.Categoria).Grafic = no;
            }
            DateTime date = DateTime.Today;
            listView.ItemsSource = null;
            listView.ItemsSource = cat;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            var akcja = await DisplayActionSheet("Czy chcesz zakończyć zakupy?", "Anuluj", "Tak");
            switch (akcja)
            {
                case "Tak":
                    await Navigation.PopAsync();  
                break;
            }
        }
    }
}