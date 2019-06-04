using Shopping.ListaZakupow;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Shopping
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListWithCost : ContentPage
	{
        ObservableCollection<Things> cat = new ObservableCollection<Things>();
        decimal sum = 0;
        public ListWithCost ()
		{
			InitializeComponent ();
		}

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var cate = e.SelectedItem as Things;
            var akcja = await DisplayActionSheet("Czy chcesz usunac ten produkt?", "Anuluj", "Tak","+","-");
            switch (akcja)
            {
                case "Tak":
                    sum -= cate.Price;
                    cat.Remove(cate);
                    break;
                case "+":
                    sum += cate.Price;
                    cate.Number += 1;
                    break;
                case "-":
                    sum -= cate.Price;
                    cate.Number -= 1;   
                    if(cate.Number==0)
                    {
                        cat.Remove(cate);
                    }
                    break;
                
            }
            amount.Text = String.Format("{0:N2}", sum);
            listView.ItemsSource = null;
            listView.ItemsSource = cat;
        }
        private async void Scan_Clicked(object sender, EventArgs e)
        {
            var scan = new ZXingScannerPage();
            await Navigation.PushAsync(scan);
            scan.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopAsync();
                    Find(Int32.Parse(result.ToString()));
                });
            };

        }
        public void Find(int result1)
        {
            SqlConnection sqlConnection = new SqlConnection("Server=tcp:mdlejtecole.database.windows.net,1433;Initial Catalog=ShopApp2;Persist Security Info=False;" +
            "User ID=MDlejtecole;Password=muza!345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Produkty WHERE KodKreskowy =" + result1, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            
            decimal price = 0;
           
            if (reader.GetDecimal(6) != 0)
            {
                price= reader.GetDecimal(5) * ((100 - reader.GetDecimal(6)) / 100);
                sum += price;
            }
            else
            {
                price= reader.GetDecimal(5);
                sum += price;
            }
            cat.Add(new Things() { Name = reader.GetString(3), Mark = reader.GetString(2), Number = 1, Price = price});
            reader.Close();
            listView.ItemsSource = null;
            listView.ItemsSource = cat;
            amount.Text = String.Format("{0:N2}", sum);

        }
    }
}