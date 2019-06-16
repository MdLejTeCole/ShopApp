using System;
using System.Collections.Generic;
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
    public partial class Scaner : ContentPage
    {
        public Scaner()
        {
            InitializeComponent();

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
        private void Find(int result1)
        {
            SqlConnection sqlConnection = new SqlConnection("");
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Produkty WHERE KodKreskowy =" + result1, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            mark.Text = reader.GetString(2);
            name.Text = reader.GetString(3);
            taste.Text = "";
            taste.Text = reader.GetString(4);
            if (reader.GetDecimal(6) != 0)
            {
                price.Text = (String.Format("{0:N2}",(reader.GetDecimal(5) * ((100-reader.GetDecimal(6)) / 100)))).ToString();
                price.TextColor = Color.Red;
            }
            else
            {
                price.Text = reader.GetDecimal(5).ToString();
                price.TextColor = Color.Black;
            }
            reader.Close();
        }
    }
}