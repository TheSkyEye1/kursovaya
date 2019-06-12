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
using System.Windows.Shapes;

namespace BcpaTbIй_so_per
{
    /// <summary>
    /// Логика взаимодействия для imsucc.xaml
    /// </summary>
    public partial class imsucc : Window
    {
        BitmapImage minepng;
        public imsucc(int[,] massive)
        {
            InitializeComponent();
            minepng = new BitmapImage(new Uri(@"pack://application:,,,/img/Podryv-zhopy-minoy-dlya-Sergo.png", UriKind.Absolute));
            gridyc.Children.Clear();
            gridyc.IsEnabled = true;
            gridyc.Rows = 10;
            gridyc.Columns = 10;
            gridyc.Margin = new Thickness(0, 35, 0, 0);
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = minepng;
            for (int i = 0; i < 100; i++)
            {
                Button but = new Button();
                but.Tag = i;
                but.Width = 33;
                but.Height = 33;
                but.Margin = new Thickness(2);
                but.BorderBrush = Brushes.Green;
                but.BorderThickness = new Thickness(2);
                but.Foreground = Brushes.Green;
                but.Background = Brushes.Black;
                if(massive[i % 10, i / 10] == 9)
                {
                    but.FontSize = 20;
                    but.Content = '•';
                }
                gridyc.Children.Add(but);

            }
        }
    }
}
