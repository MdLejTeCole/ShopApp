using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Shopping
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            listView.ItemsSource = new List<NextPages>
            {               
                new NextPages {Name="Strona główna", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", NewPages=new FirstPage()},
                new NextPages {Name="Gazetka", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", NewPages=new Newspaper()},
                new NextPages {Name="Karta MB", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", NewPages=new CardMB()},
                new NextPages {Name="Lista zakupów", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", NewPages = new Lista()},
                new NextPages {Name="Skaner", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", NewPages=new Scaner()},
                new NextPages {Name="Profil", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", NewPages = new Profile()},
                new NextPages {Name="Ustawienia", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", NewPages=new Settings()},
                new NextPages {Name="Pomoc", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", NewPages = new Settings()}
            };
            
        }
        void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as NextPages;
            Detail = new NavigationPage(contact.NewPages);
            IsPresented = false;
        }
    }
}
