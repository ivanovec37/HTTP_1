using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;


namespace HTTP_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>\
    /// 
    
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

        }

        private async void AddressButton_Click(object sender, RoutedEventArgs e)
        {
            if (AdressTextBox.Text == "") return;
            using var client = new HttpClient();
            ConclusionTextBoks.Text = await client.GetStringAsync(AdressTextBox.Text);

            HttpResponseMessage httpResponseMessage = await client.GetAsync(AdressTextBox.Text);
            ResponseCode.Text = httpResponseMessage.ReasonPhrase;

            await File.AppendAllTextAsync("Saved text", ConclusionTextBoks.Text.ToString(), Encoding.UTF8);


        }

        private  void Button_Click(object sender, RoutedEventArgs e)
        {
            ResponseCode.Text = "";
            AdressTextBox.Text = "";
            ConclusionTextBoks.Text = "";
            WebRequest request = WebRequest.Create("http://ya.ru");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                ConclusionTextBoks.Text = $" Компьютер подсоединен к интернет";
            }
            else
            { 
                ConclusionTextBoks.Text = $"Компьютер не подсоединен к интернет";
            }

        }
       
    }
}