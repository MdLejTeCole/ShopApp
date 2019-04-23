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
            
            listView.ItemsSource = new List<Contact>
            {               
                new Contact {Name="Lista Zakupów", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", Pages=new AddPage()},
                new Contact {Name="Promocje", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", Pages=new AddPage()},
                new Contact {Name="Karta MB", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", Pages=new AddPage()},
                new Contact {Name="Skaner", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", Pages = new Settings()},
                new Contact {Name="Dodaj produkt", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", Pages=new AddPage()},
                new Contact {Name="Profil", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", Pages = new Settings()},
                new Contact {Name="Ustawienia", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", Pages=new AddPage()},
                new Contact {Name="Wiecej informacji", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", Pages = new Settings()},
                new Contact {Name="Pomoc", ImageUrl="http://wiki.dwscoalition.org/wiki/images/3/3f/Userhead-100x100-unfaded.png", Pages = new Settings()}
            };
            
        }
        void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as Contact;
            Detail = new NavigationPage(contact.Pages);
            IsPresented = false;
        }
    }
}
