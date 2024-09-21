using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFProductShop.Model;

namespace WPFProductShop.Windows
{
	/// <summary>
	/// Логика взаимодействия для Registration.xaml
	/// </summary>
	public partial class Registration : Window
	{
		public Registration()
		{
			InitializeComponent();
		}


		private void Button_authorization(object sender, RoutedEventArgs e)
		{

		}

		private void Button_registration(object sender, RoutedEventArgs e)
		{
			if(NamePassword.Text == NamePasswordRepeat.Text)
			{
				var login = NameLogin.Text;
				var password = NamePassword.Text;

				using var httpclient = new HttpClient();
				var user = new User { Login = login, Password = password };
				var response = httpclient.PostAsJsonAsync("https://localhost:7227/Register", user).Result;



			}
			else
			{
				MessageBox.Show("Вы не заполнили все поля паролей");
			}

		}

		private void Button_forgot(object sender, RoutedEventArgs e)
		{

		}
	}
}
