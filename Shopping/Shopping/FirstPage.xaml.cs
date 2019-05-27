using System;
using System.Collections.Generic;
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
            TabUrl[0] = "https://static.wirtualnemedia.pl/media/top/Biedronka-WielkanocSlodziaki655.png";
            TabUrl[1] = "https://i.ytimg.com/vi/BK-agFKy8a0/maxresdefault.jpg";
            TabUrl[2] = "http://wybieramkonto.pl/wp-content/uploads/2019/01/400ZL-DO-BIEDRONKA.png";
            TabUrl[3] = "https://g.eu003.leafletcdns.com/pl/data/18/15547/0_s.jpg?t=1556700848";
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