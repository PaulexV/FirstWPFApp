using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WeenoveTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            Image[] ImageArray = new Image[10];

            for (int i = 0; i < 10; i++)
            {
                Image Image = new();
                Image.Width = 100;
                Image.Height = 100;
                ImageArray[i] = Image;
                Panel.Children.Add(ImageArray[i]);

                ImageArray[i].Source = new BitmapImage(new Uri("https://source.unsplash.com/random")); ;
            }
        }

        private void AddImages(string str)
        {
            Image img = new();
            img.Width = 100;
            img.Height = 100;

            BitmapImage Userbi = new();
            Userbi.BeginInit();
            Userbi.UriSource = new Uri(str);
            Userbi.EndInit();

            img.Source = Userbi;

            Panel.Children.RemoveAt(Panel.Children.Count - 10);
            Panel.Children.Add(img);
        }

        private void ButtonAddImage_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new();

            bool? response = openFileDialog.ShowDialog();

            if(response == true)
            {
                string filepath = openFileDialog.FileName;

                AddImages(filepath);
            }
        }
    }
}
