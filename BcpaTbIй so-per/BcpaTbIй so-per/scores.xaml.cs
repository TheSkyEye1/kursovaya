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
using System.Data.SQLite;

namespace BcpaTbIй_so_per
{
    /// <summary>
    /// Логика взаимодействия для scores.xaml
    /// </summary>
    public partial class scores : Window
    {
        bool firsttime = true;
        bool ooooo = false;
        bool MOGUYAZAKRITETOGOVNOUZHE = false;
        BitmapImage minecheck;
        public class data
        {
            public int uid { get; set; }
            public string name { get; set; }
            public int time { get; set; }
            public int highscore { get; set; }
        }
        List<data> info = new List<data>();

        sql sql1 = new sql();


        public int scures = 0;
        public int tumes = 0;
        public scores(int score, int time)
        {
            InitializeComponent();
            minecheck = new BitmapImage(new Uri(@"pack://application:,,,/img/knopka-vykl.png", UriKind.Absolute));
            scures = score;
            tumes = time;
            win_name.MaxLength = 11;
            somegrid.IsReadOnly = true;
            игеук.IsEnabled = false;

            somegrid.ItemsSource = sql1.output();
            somegrid.Items.Refresh();
           

        }

   

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            qqq.IsEnabled = false;
            sql1.input(scures, tumes, win_name.Text);
            somegrid.ItemsSource = sql1.output();
            somegrid.Items.Refresh();
            ooooo = true;
            win_name.IsReadOnly = true;
        }

        private void Win_name_MouseEnter(object sender, MouseEventArgs e)
        {
            if(firsttime == true)
            {
                win_name.Text = null;
                firsttime = false;
            }
        }

        private void Qqq_MouseEnter(object sender, MouseEventArgs e)
        {
            qqq.Foreground = Brushes.Red;
        }

        private void Qqq_MouseLeave(object sender, MouseEventArgs e)
        {
            qqq.Foreground = Brushes.White;
        }

        private void Win_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (win_name.Text == "" || win_name.Text == "Впишите Имя ")
                qqq.IsEnabled = false;
            else
            {
                if (ooooo == true)
                {
                    qqq.IsEnabled = false;
                }
                else
                {
                    qqq.IsEnabled = true;
                }
            }
                
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MOGUYAZAKRITETOGOVNOUZHE = true;
            this.Close();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            

            but.Height = 80;
            but.Width = 80;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = minecheck;
            but.Background = ib;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            
            but.Height = 60;
            but.Width = 60;
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = minecheck;
            but.Background = ib;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MOGUYAZAKRITETOGOVNOUZHE == false)
            {
                e.Cancel = true;
            }
        }
    }
}
