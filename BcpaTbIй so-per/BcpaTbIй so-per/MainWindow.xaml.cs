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

namespace BcpaTbIй_so_per
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage minepng;
        BitmapImage butback;
        BitmapImage minecheck;
        bool perviynah = true;
        GameLogic logic = new GameLogic();
        int allah = 0;
        bool dostup = false;
        int sec;
        int min;
        int score;
        bool mineheker = false;
        int winer;
        int flagcount;
        bool startbutton = false;
        bool gridыч = false;


        System.Windows.Threading.DispatcherTimer Timer;
        public MainWindow()
        {
            InitializeComponent();
            minepng = new BitmapImage(new Uri(@"pack://application:,,,/img/Podryv-zhopy-minoy-dlya-Sergo.png", UriKind.Absolute));
            butback = new BitmapImage(new Uri(@"pack://application:,,,/img/zaschita-ot-govna228.png", UriKind.Absolute));
            minecheck = new BitmapImage(new Uri(@"pack://application:,,,/img/FLAG-MNE-V-ZAD.png", UriKind.Absolute));
            boomer.MaxLength = 2;
            gridyc.Children.Clear();
            gridyc.IsEnabled = true;
            gridyc.Rows = 10;
            gridyc.Columns = 10;
            gridyc.Margin = new Thickness(3);
            logic.sozdavator(10);
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = null;
            minechanger.BorderThickness = new Thickness(2);
            for (int i = 0; i < 100; i++)
            {
                Button but = new Button();
                but.Tag = i;
                but.Width = 50;
                but.Height = 50;
                but.Content = ' ';
                but.Margin = new Thickness(2);
                but.Click += But_Click;
                but.Background = ib;
                but.MouseEnter += But_MouseEnter;
                but.MouseLeave += But_MouseLeave;
                but.BorderBrush = Brushes.Blue;
                but.BorderThickness = new Thickness(2);
                
                gridyc.Children.Add(but);
                
            }
        }
        private void But_Click(object sender, RoutedEventArgs e)
        {
            if (gridыч == true)
            {
                if (mineheker == false)
                {
                    if (((Button)sender).Background != Brushes.Crimson)
                    {
                        if (dostup == true)
                        {
                            int tag = Convert.ToInt32(((Button)sender).Tag);
                            if (perviynah == true)
                            {
                                if (logic.celler(tag % 10, tag / 10) < 10)
                                {
                                    logic.zakladka(allah, tag);
                                    logic.zapolnyator();
                                    perviynah = false;
                                    umnozigifashizm.IsEnabled = false;
                                    Timer.Start();
                                    flagcount = allah;
                                    winer = 0;
                                    if (logic.celler(tag % 10, tag / 10) == 0)
                                    {
                                        suker.Content = Convert.ToString(score);
                                        logic.otkrivashka(tag % 10, tag / 10);
                                        Button[] but1 = new Button[gridyc.Children.Count];
                                        gridyc.Children.CopyTo(but1, 0);

                                        for (int i = 0; i < but1.Length; i++)
                                        {
                                            int h = Convert.ToInt32((but1[i]).Tag);

                                            if (logic.celler(h % 10, h / 10) >= 10)
                                            {
                                                logic.revert(h % 10, h / 10);
                                                (but1[i]).FontSize = 32;
                                                if (logic.celler(h % 10, h / 10) == 0)
                                                {

                                                    (but1[i]).Content = ' ';
                                                    (but1[i]).Background = null;
                                                    logic.opened(h % 10, h / 10);
                                                }
                                                else
                                                {

                                                    (but1[i]).Background = Brushes.LightBlue;
                                                    (but1[i]).Content = logic.celler(h % 10, h / 10);
                                                    logic.opened(h % 10, h / 10);

                                                }
                                            }

                                        }
                                        score += 10 * allah;
                                        suker.Content = " " + Convert.ToString(score);
                                    }
                                    else
                                    if (logic.celler(tag % 10, tag / 10) > 0 && logic.celler(tag % 10, tag / 10) < 9)
                                    {

                                        ((Button)sender).Content = logic.celler(tag % 10, tag / 10);
                                        ((Button)sender).Background = Brushes.LightBlue;
                                        ((Button)sender).FontSize = 32;
                                        logic.opened(tag % 10, tag / 10);
                                        score += 10 * allah;
                                        suker.Content = " " + Convert.ToString(score);
                                        
                                    }
                                }
                            }
                            else
                            {
                                if (logic.celler(tag % 10, tag / 10) < 10)
                                {
                                    if (logic.celler(tag % 10, tag / 10) == 0)
                                    {
                                        logic.otkrivashka(tag % 10, tag / 10);
                                        Button[] but1 = new Button[gridyc.Children.Count];
                                        gridyc.Children.CopyTo(but1, 0);

                                        for (int i = 0; i < but1.Length; i++)
                                        {
                                            int h = Convert.ToInt32((but1[i]).Tag);

                                            if (logic.celler(h % 10, h / 10) >= 10)
                                            {
                                                logic.revert(h % 10, h / 10);
                                                (but1[i]).FontSize = 32;
                                                if (logic.celler(h % 10, h / 10) == 0)
                                                {
                                                    (but1[i]).Content = ' ';
                                                    (but1[i]).Background = null;
                                                    logic.opened(h % 10, h / 10);

                                                }
                                                else
                                                {
                                                    (but1[i]).Background = Brushes.LightBlue;
                                                    (but1[i]).Content = logic.celler(h % 10, h / 10);
                                                    logic.opened(h % 10, h / 10);

                                                }
                                            }

                                        }
                                        score += 10 * allah;
                                        suker.Content = " " + Convert.ToString(score);
                                    }
                                    else
                                    if (logic.celler(tag % 10, tag / 10) > 0 && logic.celler(tag % 10, tag / 10) != 9)
                                    {
                                        ((Button)sender).Content = logic.celler(tag % 10, tag / 10);
                                        ((Button)sender).Background = Brushes.LightBlue;
                                        ((Button)sender).FontSize = 32;
                                        logic.opened(tag % 10, tag / 10);
                                        score += 10 * allah;
                                        suker.Content = " " + Convert.ToString(score);

                                    }
                                    else
                                    if (logic.celler(tag % 10, tag / 10) == 9)
                                    {
                                        Button[] mine = new Button[gridyc.Children.Count];
                                        gridyc.Children.CopyTo(mine, 0);
                                        for (int i = 0; i < mine.Length; i++)
                                        {

                                            int n = Convert.ToInt32((mine[i]).Tag);
                                            if (logic.celler(n % 10, n / 10) == 9)
                                            {
                                                ImageBrush ib = new ImageBrush();
                                                ib.ImageSource = minepng;
                                                (mine[i]).Background = ib;
                                            }
                                        }
                                        Timer.Stop();
                                        MessageBox.Show("Проигрыш");
                                        umnozigifashizm.IsEnabled = true;
                                        boomer.IsReadOnly = false;
                                        startbutton = false;
                                        umnozigifashizm.Foreground = Brushes.White;
                                        gridыч = false;

                                    }
                                }
                            }

                        }
                    }
                }
                else
                {
                    if (perviynah == false)
                    {
                        int tag = Convert.ToInt32(((Button)sender).Tag);
                        if (logic.celler(tag % 10, tag / 10) >= 0)
                        {
                            if (flagcount != 0)
                            {
                                ImageBrush ib = new ImageBrush();
                                ib.ImageSource = minecheck;
                                ((Button)sender).Background = ib;
                                if (logic.celler(tag % 10, tag / 10) == 9)
                                {
                                    logic.umnozhator(tag % 10, tag / 10);
                                    winer++;
                                    flagcount -= 1;
                                }
                                else
                                {
                                    logic.umnozhator(tag % 10, tag / 10);
                                    flagcount -= 1;
                                }
                            }
                        }
                        else
                        {
                            ((Button)sender).Background = Brushes.LightBlue;
                            if (logic.celler(tag % 10, tag / 10) == -9)
                            {
                                logic.umnozhator(tag % 10, tag / 10);
                                winer--;
                                flagcount += 1;

                            }
                            else
                            {
                                logic.umnozhator(tag % 10, tag / 10);
                                flagcount += 1;
                            }
                        }
                        if (winer == allah)
                        {
                            Timer.Stop();

                            scores scor = new scores(score, (min * 60) + sec);
                            scor.Owner = this;
                            scor.Show();
                            gridыч = false;
                            umnozigifashizm.IsEnabled = true;
                            boomer.IsReadOnly = false;
                            startbutton = false;
                            umnozigifashizm.Foreground = Brushes.White;
                        }
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (startbutton == false)
            {
                try
                {
                    allah = Convert.ToInt32(boomer.Text);
                    labradoryc.Content = "     0:00";
                    sec = 0;
                    min = 0;
                    gridyc.Children.Clear();
                    gridyc.IsEnabled = true;
                    gridyc.Rows = 10;
                    gridyc.Columns = 10;
                    gridyc.Margin = new Thickness(3);
                    logic.sozdavator(10);
                    suker.Content = "      0";
                    score = 0;
                    for (int i = 0; i < 100; i++)
                    {
                        Button but = new Button();
                        but.Tag = i;
                        but.Width = 50;
                        but.Height = 50;
                        but.Content = ' ';
                        but.Margin = new Thickness(2);
                        but.Click += But_Click;
                        but.Background = Brushes.LightBlue;
                        but.MouseEnter += But_MouseEnter;
                        but.MouseLeave += But_MouseLeave;
                        but.BorderBrush = Brushes.Blue;
                        but.BorderThickness = new Thickness(2);
                        but.FontFamily = new FontFamily("Consolas");
                        gridyc.Children.Add(but);
                        

                    }
                    perviynah = true;
                    dostup = true;
                    umnozigifashizm.IsEnabled = false;
                    Timer = new System.Windows.Threading.DispatcherTimer();
                    Timer.Tick += new EventHandler(dispatcherTimer_Tick);
                    Timer.Interval = new TimeSpan(0, 0, 1);
                }
                catch { MessageBox.Show("Пиши циферки"); };
                suker.Content = " 00000";
                labradoryc.Content = " 00:00";
                boomer.IsReadOnly = true;
                umnozigifashizm.Foreground = Brushes.Crimson;
                startbutton = true;
                gridыч = true;
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            string secyndyc = "00";
            string minutyc = "00";
            sec++;
            if (sec == 59)
            {
                min++;
                sec = 0;
            }

            if (sec < 10)
                secyndyc = '0' + Convert.ToString(sec);
            else
                secyndyc = Convert.ToString(sec);
            if (min < 10)
                minutyc = '0' + Convert.ToString(min);
            else
                minutyc = Convert.ToString(min);
            labradoryc.Content = " " + minutyc + ':' + secyndyc;

        }

        private void Minechanger_Click(object sender, RoutedEventArgs e)
        {
            if (mineheker == false)
            {
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = minecheck;
                mineheker = true;
                minechanger.Background = ib;
            }
            else
            {
                ImageBrush ib = new ImageBrush();
                ib.ImageSource = minepng;
                mineheker = false;
                minechanger.Background = ib;
            }
        }

        private void Umnozigifashizm_MouseEnter(object sender, MouseEventArgs e)
        {
            if (startbutton == false)
            {
                umnozigifashizm.Foreground = Brushes.Crimson;
            }
        }

        private void Umnozigifashizm_MouseLeave(object sender, MouseEventArgs e)
        {
            if (startbutton == false)
            {
                umnozigifashizm.Foreground = Brushes.White;
            }
        }

        private void Minechanger_MouseEnter(object sender, MouseEventArgs e)
        {
            minechanger.BorderBrush = Brushes.Red;
            minechanger.BorderThickness = new Thickness(2);
        }

        private void Minechanger_MouseLeave(object sender, MouseEventArgs e)
        {
            minechanger.BorderBrush = null;
            minechanger.BorderThickness = new Thickness(2);
        }
        private void But_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (gridыч == true)
            {
                ((Button)sender).BorderBrush = Brushes.SeaGreen;
            }
        }

        private void But_MouseLeave(object sender, RoutedEventArgs e)
        {
            if (gridыч == true)
            {
                ((Button)sender).BorderBrush = Brushes.Blue;
            }
        }
    }
}

