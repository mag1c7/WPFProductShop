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
	/// Логика взаимодействия для Auth.xaml
	/// </summary>
	public partial class Auth : Window
	{
		public Auth()
		{
			InitializeComponent();
		}

		private void Button_auth(object sender, RoutedEventArgs e)
		{
			var login = NameLogin.Text;
			var password = NamePassword.Text;

			using var httpclient = new HttpClient();
			var user = httpclient.GetFromJsonAsync<User>($"https://localhost:7227/Login?login={login}&password={password}").Result;
			if (user != null)
			{
				MessageBox.Show($"Вы успешно вошли");
			}
			else
			{
				MessageBox.Show($"Неправильный логин или пароль");
			}
		}

		private void Button_registration(object sender, RoutedEventArgs e)
		{
			Hide();
			new Registration().Show();
		}

		private void Button_forgot(object sender, RoutedEventArgs e)
		{
			new WindowForgot().ShowDialog();
		}
	}
}
