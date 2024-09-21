using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
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

namespace WPFProductShop.Windows
{
	/// <summary>
	/// Логика взаимодействия для WindowForgot.xaml
	/// </summary>
	public partial class WindowForgot : Window
	{
		private int confirmationCode;
		public WindowForgot()
		{
			InitializeComponent();
		}
		private void Button_SendCode(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrEmpty(EmailTextBox.Text))
			{
				MessageBox.Show("Пожалуйста, введите вашу почту.");
				return;
			}

			Random random = new Random();
			confirmationCode = random.Next(1000, 9999); // Генерация кода

			MailAddress from = new MailAddress("mbydin@mail.ru", "Maksim");
			MailAddress to = new MailAddress(EmailTextBox.Text);
			MailMessage m = new MailMessage(from, to)
			{
				Subject = "Код-подтверждения",
				Body = $"<h2>Ваш код подтверждения для сброса пароля - {confirmationCode}</h2>",
				IsBodyHtml = true
			};

			SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587)
			{
				Credentials = new NetworkCredential("mbydin@mail.ru", "vAhkCaFp634Uyjww4htz"),
				EnableSsl = true
			};

			try
			{
				smtp.Send(m);
				MessageBox.Show("Письмо отправлено успешно.");
			}
			catch (SmtpException ex)
			{
				MessageBox.Show($"Ошибка отправки письма: {ex.Message}");
			}
		}

		private void Button_ConfirmCode(object sender, RoutedEventArgs e)
		{
			if (int.TryParse(CodeTextBox.Text, out int enteredCode))
			{
				if (enteredCode == confirmationCode)
				{
					MessageBox.Show("Код подтвержден.");
					this.Close();

				}
				else
				{
					MessageBox.Show("Неверный код подтверждения.");
				}
			}
			else
			{
				MessageBox.Show("Пожалуйста, введите корректный код.");
			}
		}
	}
}
