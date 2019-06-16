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
	public partial class BasicList : ContentPage
	{
        ObservableCollection<Categories> cat = new ObservableCollection<Categories>();
        
        public BasicList ()
		{
			InitializeComponent ();
            
            SqlConnection sqlConnection = new SqlConnection("");
            sqlConnection.Open();
            
           
            for (int i = 1; i < 18; i++)
            {
                SqlCommand cmd = new SqlCommand("SELECT PodKategoria FROM Kategorie WHERE IdKategoria =" + i, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                cat.Add(new Categories() { Categoria = reader.GetString(0), Grafic = "https://www.5ssupply.com/wp-content/uploads/2016/12/5S-Floor-Marking-Symbol-Xs-Profile.jpg", Status = false });
                reader.Close();

            }
            listView.ItemsSource = GetCategories();
            
        }
        IEnumerable<Categories> GetCategories(string searchText = null)
        {           

            if (String.IsNullOrWhiteSpace(searchText))
                return cat;

            return cat.Where(c => c.Categoria.ToLower().Contains(searchText.ToLower()));
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var akcja = await DisplayActionSheet("Czy chcesz zakończyć zakupy?", "Anuluj", "Tak");
            switch (akcja)
            {
                case "Tak":
                    Save();
                    break;
            }
          
        }
        private void Save()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=tcp:mdlejtecole.database.windows.net,1433;Initial Catalog=ShopApp2;Persist Security Info=False;" +
               "User ID=MDlejtecole;Password=muza!345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();
            
            DateTime thisDay = DateTime.Today;
            string date1 = string.Format("{0:yyyy-MM-dd}", thisDay);
            int id = 1;
            for (int i = 1; i < 18; i++)
            {

                if (cat[i - 1].Status == true)
                {

                    SqlCommand cmd = new SqlCommand("Select IdKategoria from Kategorie where PodKategoria='" + cat[i - 1].Categoria + "'", sqlConnection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    int a = reader.GetInt32(0);

                    reader.Close();
                    cmd = new SqlCommand("insert into ListaZakupow values ('" + id + "','" + a + "','" + "','" + date1 + "')", sqlConnection);
                    cmd.ExecuteNonQuery();
                }

            }
            Navigation.PopAsync();
        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetCategories(e.NewTextValue);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string ok = "https://st2.depositphotos.com/7107694/10595/v/950/depositphotos_105958650-stock-illustration-ok-flat-vector-symbol.jpg";
            string no = "https://www.5ssupply.com/wp-content/uploads/2016/12/5S-Floor-Marking-Symbol-Xs-Profile.jpg";
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
            listView.ItemsSource = GetCategories();
        }

    }
}