using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shopping
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FirstPage : ContentPage
	{
        string[] TabUrl = new string[4];
        string[] TabUrl2 = new string[2];
        int adCounter=0;

        private Timer delayTimer;

        public FirstPage ()
		{
			InitializeComponent ();

            SqlConnection sqlConnection = new SqlConnection("Server=tcp:mdlejtecole.database.windows.net,1433;Initial Catalog=ShopApp2;Persist Security Info=False;" +
                "User ID=MDlejtecole;Password=muza!345;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            sqlConnection.Open();
            for (int i = 1; i < 5; i++)
            {
                SqlCommand cmd = new SqlCommand("SELECT Link FROM Reklamy WHERE Id =" + i, sqlConnection);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                TabUrl[i - 1] = reader.GetString(0);
                reader.Close();
            }
            ad.Source = TabUrl[0];
            TabUrl2[0] = "https://vallecentral.cl/ipvc/images/images-slide/boat.png";
            TabUrl2[1] = "https://www.ypoint.de/gfx/gelberPunkt.png";
            ad0.Source = TabUrl2[1];
            ad1.Source = TabUrl2[0];
            ad2.Source = TabUrl2[0];
            ad3.Source = TabUrl2[0];
            
            ButtonLeft.Source = "http://www.clker.com/cliparts/L/Y/I/S/g/X/yellow-arrow-md.png";
            ButtonRight.Source = "http://www.clker.com/cliparts/L/Y/I/S/g/X/yellow-arrow-md.png";

            delayTimer = new System.Timers.Timer();
            delayTimer.Interval = 7000;
            delayTimer.Elapsed += (o, e) => NextPage();
            delayTimer.Start();
        }
        private void NextPage()
        {
            adCounter++;
            if (adCounter > 3)
            {
                adCounter = 0;
            }
            ad.Source = TabUrl[adCounter];

            if (adCounter == 0)
            {
                ad3.Source = TabUrl2[0];
                ad0.Source = TabUrl2[1];
            }
            else if (adCounter == 1)
            {
                ad0.Source = TabUrl2[0];
                ad1.Source = TabUrl2[1];
            }
            else if (adCounter == 2)
            {
                ad1.Source = TabUrl2[0];
                ad2.Source = TabUrl2[1];
            }
            else if (adCounter == 3)
            {
                ad2.Source = TabUrl2[0];
                ad3.Source = TabUrl2[1];
            }
            delayTimer.Stop();
            delayTimer.Start();
        }
        private void ButtonRight_Clicked(object sender, EventArgs e)
        {
            NextPage();
        }

        private void ButtonLeft_Clicked(object sender, EventArgs e)
        {
            adCounter--;
            if (adCounter < 0)
            {
                adCounter = 3;
            }
            ad.Source = TabUrl[adCounter];

            if (adCounter == 0)
            {
                ad1.Source = TabUrl2[0];
                ad0.Source = TabUrl2[1];
            }
            else if (adCounter == 1)
            {
                ad2.Source = TabUrl2[0];
                ad1.Source = TabUrl2[1];
            }
            else if (adCounter == 2)
            {
                ad3.Source = TabUrl2[0];
                ad2.Source = TabUrl2[1];
            }
            else if (adCounter == 3)
            {
                ad0.Source = TabUrl2[0];
                ad3.Source = TabUrl2[1];
            }
        }
    }
}