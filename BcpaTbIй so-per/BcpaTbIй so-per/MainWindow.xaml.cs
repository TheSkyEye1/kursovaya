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
        int tagster;

        
        System.Windows.Threading.DispatcherTimer Timer;
        public MainWindow()
        {
            InitializeComponent();

            gridyc.Children.Clear();
            gridyc.IsEnabled = true;
            gridyc.Rows = 10;
            gridyc.Columns = 10;
            gridyc.Margin = new Thickness(3);
            logic.sozdavator(10);
            for (int i = 0; i < 100; i++)
            {
                Button but = new Button();
                but.Tag = i;
                but.Width = 50;
                but.Height = 50;
                but.Content = ' ';
                but.Margin = new Thickness(2);
                but.Click += But_Click;
                gridyc.Children.Add(but);
            }
        }
        private void But_Click(object sender, RoutedEventArgs e)
        {
            if (mineheker == false)
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
                                score += 10 * allah;
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
                                            (but1[i]).Background = Brushes.Azure;
                                            logic.opened(h % 10, h / 10);
                                        }
                                        else
                                        {
                                            score += 10 * allah;
                                            (but1[i]).Background = Brushes.LightBlue;
                                            (but1[i]).Content = logic.celler(h % 10, h / 10);
                                            logic.opened(h % 10, h / 10);
                                        }
                                    }

                                }
                            }
                            else
                            if (logic.celler(tag % 10, tag / 10) > 0 && logic.celler(tag % 10, tag / 10) < 9)
                            {

                                ((Button)sender).Content = logic.celler(tag % 10, tag / 10);
                                ((Button)sender).Background = Brushes.LightBlue;
                                ((Button)sender).FontSize = 32;
                                score += 10 * allah;
                                suker.Content = Convert.ToString(score);
                                logic.opened(tag % 10, tag / 10);

                            }
                        }
                    }
                    else
                    {
                        if (logic.celler(tag % 10, tag / 10) < 10)
                        {
                            if (logic.celler(tag % 10, tag / 10) == 0)
                            {
                                score += 10 * allah;
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
                                            (but1[i]).Background = Brushes.Azure;
                                            logic.opened(h % 10, h / 10);

                                        }
                                        else
                                        {
                                            score += 10 * allah;
                                            (but1[i]).Background = Brushes.LightBlue;
                                            (but1[i]).Content = logic.celler(h % 10, h / 10);
                                            logic.opened(h % 10, h / 10);
                                        }
                                    }

                                }
                            }
                            else
                            if (logic.celler(tag % 10, tag / 10) > 0 && logic.celler(tag % 10, tag / 10) != 9)
                            {

                                score += 10 * allah;
                                suker.Content = Convert.ToString(score);
                                ((Button)sender).Content = logic.celler(tag % 10, tag / 10);
                                ((Button)sender).Background = Brushes.LightBlue;
                                ((Button)sender).FontSize = 32;
                                logic.opened(tag % 10, tag / 10);

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
                                        (mine[i]).Content = 9;
                                        (mine[i]).Background = Brushes.Red;
                                        (mine[i]).FontSize = 32;
                                    }
                                }
                                Timer.Stop();
                                MessageBox.Show("Проигрыш");
                                gridyc.IsEnabled = false;
                                umnozigifashizm.IsEnabled = true;
                                boomer.IsEnabled = true;

                            }
                        }
                    }

                }
            }
            else
            {
                if (perviynah == false)
                {
                    if (((Button)sender).Background != Brushes.Crimson)
                    {
                        if (flagcount != 0)
                        {
                            int tag = Convert.ToInt32(((Button)sender).Tag);
                            ((Button)sender).Background = Brushes.Crimson;
                            if (logic.celler(tag % 10, tag / 10) == 9)
                            {
                                winer++;
                                flagcount -= 1;
                            }
                            else
                            {
                                flagcount -= 1;
                            }
                        }
                    }
                    else
                    {
                        int tag = Convert.ToInt32(((Button)sender).Tag);
                        ((Button)sender).Background = Brushes.Gray;
                        if (logic.celler(tag % 10, tag / 10) == 9)
                        {
                            winer--;
                            flagcount += 1;
                        }
                        else
                        {
                            flagcount += 1;
                        }
                    }
                    if(winer == allah)
                    {
                        Timer.Stop();

                        scores scor = new scores(score, (min*60)+sec);
                        scor.Owner = this;
                        scor.Show();
                        
                        umnozigifashizm.IsEnabled = true;
                        boomer.IsEnabled = true;
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try {
                allah = Convert.ToInt32(boomer.Text); 
            labradoryc.Content = "0:00";
            sec = 0;
            min = 0;
            gridyc.Children.Clear();
            gridyc.IsEnabled = true;
            gridyc.Rows = 10;
            gridyc.Columns = 10;
            gridyc.Margin = new Thickness(3);
            logic.sozdavator(10);
            suker.Content = '0';
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
                gridyc.Children.Add(but);
            }
            perviynah = true;
            dostup = true;
            umnozigifashizm.IsEnabled = false;
            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 1);
            boomer.IsEnabled = false;
            }
            catch { MessageBox.Show("Пиши циферки"); };
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            string secyndyc = "0";
            sec++;
            if(sec == 59)
            {
                min++;
                sec = 0;
            }

            if (sec < 10)
              secyndyc = '0' + Convert.ToString(sec);
            else
                secyndyc = Convert.ToString(sec);
            labradoryc.Content = Convert.ToString(min) + ':' + secyndyc;

        }

        private void Minechanger_Click(object sender, RoutedEventArgs e)
        {
            if (mineheker == false)
            {
                mineheker = true;
                minechanger.Content = "Миноискатель";
            }
            else
            {
                mineheker = false;
                minechanger.Content = "Искатель";
            }
        }
    }
}
