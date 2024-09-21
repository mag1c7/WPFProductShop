using System.Configuration;
using System.Data;
using System.Net.Http;
using System.Windows;
using System.Net.Http;

namespace WPFProductShop
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var handler = new HttpClientHandler();
			handler.ServerCertificateCustomValidationCallback += (httpRequestMessage, cert, cetChain, policyErrors) => true;
			var client = new HttpClient(handler);

			// Добавьте эту строку для сохранения клиента между запусками приложения
			Properties["HttpClient"] = client;
		}
	}

}
