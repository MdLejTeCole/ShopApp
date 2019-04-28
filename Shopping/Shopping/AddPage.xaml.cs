using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Shopping
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddPage : ContentPage
	{
		public AddPage ()
		{
            //int i = 1;

            //SqlConnection sqlConnection = new SqlConnection("Server = .\\MDLEJTECOLE; Database = milionerzy; Trusted_Connection = True;");
            //sqlConnection.Open();
            //SqlCommand cmd = new SqlCommand("SELECT COUNT(ID) FROM Pytaniadogry WHERE numberquestion =" + i, sqlConnection);
            //SqlDataReader reader = cmd.ExecuteReader();
            //int random1=0;
            //while (reader.Read())
            //{
            //    random1 = reader.GetInt32(0);
            //}
            //AddPage111.Text = random1.ToString();
            //reader.Close();
            //sqlConnection.Close();

            //if (contact == null)
            //    throw new ArgumentException();

            //BindingContext = contact;
            InitializeComponent ();
		}
	}
}