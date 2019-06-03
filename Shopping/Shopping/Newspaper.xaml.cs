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
    public partial class Newspaper : ContentPage
    {
        Image[] imageName = new Image[8];
        public Newspaper()
        {
            InitializeComponent();
            imageName[0] = image1;
            imageName[1] = image2;
            imageName[2] = image3;
            imageName[3] = image4;
            imageName[4] = image5;
            imageName[5] = image6;
            imageName[6] = image7;
            imageName[7] = image8;
            SqlConnection sqlConnection = new SqlConnection("Server=tcp:mdlejtecole.database.windows.net,1433;Initial Catalog=ShopApp1;Persist Security Info=False;" +
                "User ID=MDlejtecole;Password=muza!345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();
            for (int i = 1; i < 9; i++)
            {
                SqlCommand cmd = new SqlCommand("SELECT Link FROM Gazetka WHERE Id =" + i, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                imageName[i - 1].Source = reader.GetString(0);
                reader.Close();
            }
        }
    }
}