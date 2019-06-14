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
using System.Media;

namespace BcpaTbIй_so_per
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BitmapImage minepng;
        BitmapImage minecheck;
        BitmapImage lico;
        BitmapImage lico1;
        BitmapImage lico2;
        BitmapImage lico3;
        BitmapImage lico4;
        BitmapImage lico5;
        bool perviynah = true;
        GameLogic logic = new GameLogic();
        sql squilt = new sql();
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
        bool cheatopened = false;
        public int[,] massivich = new int[10, 10];
        int cheater;
        bool cancheat = false;
        int pipecc = 0;
        int licoint = 0;
        bool gameplayed = false;
        wiw1 wiw;

        MediaPlayer player = new MediaPlayer();
        MediaPlayer mineplayer = new MediaPlayer();
        MediaPlayer magic = new MediaPlayer();
        MediaPlayer tromb = new MediaPlayer();

        System.Windows.Threading.DispatcherTimer Timer;
        System.Windows.Threading.DispatcherTimer Tumer;
        System.Windows.Threading.DispatcherTimer Trimer;
        public MainWindow()
        {
            InitializeComponent();
            minepng = new BitmapImage(new Uri(@"pack://application:,,,/img/Podryv-zhopy-minoy-dlya-Sergo.png", UriKind.Absolute));
            minecheck = new BitmapImage(new Uri(@"pack://application:,,,/img/FLAG-MNE-V-ZAD.png", UriKind.Absolute));

            lico = new BitmapImage(new Uri(@"pack://application:,,,/img/Obychnoe-litso.png", UriKind.Absolute));
            lico1 = new BitmapImage(new Uri(@"pack://application:,,,/img/Vzglyad-vlevo.png", UriKind.Absolute));
            lico2 = new BitmapImage(new Uri(@"pack://application:,,,/img/Vzglyad-vpravo.png", UriKind.Absolute));
            lico3 = new BitmapImage(new Uri(@"pack://application:,,,/img/Kakoe-to-deystvie.png", UriKind.Absolute));
            lico4 = new BitmapImage(new Uri(@"pack://application:,,,/img/Pobeda.png", UriKind.Absolute));
            lico5 = new BitmapImage(new Uri(@"pack://application:,,,/img/proigrysh.png", UriKind.Absolute));

            player.Open(new Uri(@"sound\welcomtotheclub.wav", UriKind.Relative));
            player.MediaEnded += Player_MediaEnded;
            mineplayer.Open(new Uri(@"sound\waterdrop.wav", UriKind.Relative));
            mineplayer.MediaEnded += MinePlayer_MediaEnded;
            magic.Open(new Uri(@"sound\magic (2).wav", UriKind.Relative));
            magic.MediaEnded += Magic_MediaEnded;
            tromb.Open(new Uri(@"sound\tromb.wav", UriKind.Relative));
            tromb.MediaEnded += Tromb_MediaEnded;
            boomer.MaxLength = 2;
            gridyc.Children.Clear();
            gridyc.IsEnabled = true;
            gridyc.Rows = 10;
            gridyc.Columns = 10;
            gridyc.Margin = new Thickness(0,0,10,85);
            logic.sozdavator(10);
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = null;
            wiw = new wiw1();
            pi.BorderThickness = new Thickness(2);
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
            Tumer = new System.Windows.Threading.DispatcherTimer();
            Tumer.Tick += new EventHandler(dispatcherTumer_Tick);
            Tumer.Interval = new TimeSpan(0, 0, 0, 0, 350);

            Trimer = new System.Windows.Threading.DispatcherTimer();
            Trimer.Tick += new EventHandler(dispatcherTrimer_Tick);
            Trimer.Interval = new TimeSpan(0, 0, 0, 0, 400);
            spravka.BorderThickness = new Thickness(2);
            Trimer.Start();
        }
        private void But_Click(object sender, RoutedEventArgs e)
        {
            if(gameplayed == false)
            {
                if (gridыч == true)
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
                                    for (int i = 0; i < 100; i++)
                                    {
                                        massivich[i % 10, i / 10] = logic.gr[i % 10, i / 10];
                                    }
                                    logic.zapolnyator();
                                    perviynah = false;
                                    umnozigifashizm.IsEnabled = false;
                                    cancheat = true;
                                    Timer.Start();
                                    flagcount = allah;
                                    winer = 0;

                                    if (logic.celler(tag % 10, tag / 10) == 0)
                                    {
                                        Trimer.Stop();
                                        player.Play();
                                        suker.Content = Convert.ToString(score);
                                        logic.otkrivashka(tag % 10, tag / 10);
                                        Button[] but1 = new Button[gridyc.Children.Count];
                                        gridyc.Children.CopyTo(but1, 0);
                                        ImageBrush ib1 = new ImageBrush();
                                        ib1.ImageSource = lico3;
                                        umnozigifashizm.Background = ib1;
                                        Tumer.Start();

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

                                                    (but1[i]).Background = Brushes.LightCyan;
                                                    (but1[i]).Content = logic.celler(h % 10, h / 10);
                                                    logic.opened(h % 10, h / 10);

                                                }
                                            }

                                        }
                                        score += 10 * allah;
                                    }
                                    else
                                    if (logic.celler(tag % 10, tag / 10) > 0 && logic.celler(tag % 10, tag / 10) < 9)
                                    {
                                        Trimer.Stop();
                                        ImageBrush ib1 = new ImageBrush();
                                        ib1.ImageSource = lico3;
                                        umnozigifashizm.Background = ib1;
                                        Tumer.Start();
                                        player.Play();
                                        ((Button)sender).Content = logic.celler(tag % 10, tag / 10);
                                        ((Button)sender).Background = Brushes.LightCyan;
                                        ((Button)sender).FontSize = 32;
                                        logic.opened(tag % 10, tag / 10);
                                        score += 10 * allah;

                                    }
                                }
                            }
                            else
                            {
                                if (logic.celler(tag % 10, tag / 10) < 10)
                                {
                                    if (logic.celler(tag % 10, tag / 10) == 0)
                                    {
                                        Trimer.Stop();
                                        ImageBrush ib1 = new ImageBrush();
                                        ib1.ImageSource = lico3;
                                        umnozigifashizm.Background = ib1;
                                        Tumer.Start();
                                        player.Play();
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
                                                    (but1[i]).Background = Brushes.LightCyan;
                                                    (but1[i]).Content = logic.celler(h % 10, h / 10);
                                                    logic.opened(h % 10, h / 10);

                                                }
                                            }

                                        }
                                        score += 10 * allah;
                                    }
                                    else
                                    if (logic.celler(tag % 10, tag / 10) > 0 && logic.celler(tag % 10, tag / 10) != 9)
                                    {
                                        Trimer.Stop();
                                        ImageBrush ib1 = new ImageBrush();
                                        ib1.ImageSource = lico3;
                                        umnozigifashizm.Background = ib1;
                                        Tumer.Start();
                                        player.Play();
                                        ((Button)sender).Content = logic.celler(tag % 10, tag / 10);
                                        ((Button)sender).Background = Brushes.LightCyan;
                                        ((Button)sender).FontSize = 32;
                                        logic.opened(tag % 10, tag / 10);
                                        score += 10 * allah;

                                    }
                                    else
                                    if (logic.celler(tag % 10, tag / 10) == 9)
                                    {
                                        Trimer.Stop();
                                        ImageBrush ib1 = new ImageBrush();
                                        ib1.ImageSource = lico5;
                                        umnozigifashizm.Background = ib1;
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
                                        mineplayer.Play();
                                        Timer.Stop();
                                        MessageBox.Show("Подорвался!", "Проиграл");
                                        umnozigifashizm.IsEnabled = true;
                                        boomer.IsReadOnly = false;
                                        startbutton = false;
                                        umnozigifashizm.Foreground = Brushes.White;
                                        gridыч = false;

                                    }
                                }
                            }

                        }

                        if (score < 100)
                            suker.Content = " 000" + Convert.ToString(score);
                        else
                        if (score < 1000)
                            suker.Content = " 00" + Convert.ToString(score);
                        else
                        if (score < 10000)
                            suker.Content = " 0" + Convert.ToString(score);
                        else
                            suker.Content = " " + Convert.ToString(score);
                    }
                    else
                    {
                        if (perviynah == false)
                        {
                            ImageBrush ib = new ImageBrush();
                            ib.ImageSource = minecheck;
                            if (((Button)sender).Background != ib && ((Button)sender).Background != Brushes.LightCyan && ((Button)sender).Background != null)
                            {
                                magic.Play();
                                int tag = Convert.ToInt32(((Button)sender).Tag);
                                if (logic.celler(tag % 10, tag / 10) >= 0)
                                {
                                    if (flagcount != 0)
                                    {
                                        ((Button)sender).Background = ib;
                                        if (logic.celler(tag % 10, tag / 10) == 9)
                                        {
                                            logic.umnozhator(tag % 10, tag / 10);
                                            winer++;
                                            flagcount -= 1;
                                        }
                                        else
                                        {
                                            if (logic.gr[tag % 10, tag / 10] == 0)
                                            {
                                                logic.gr[tag % 10, tag / 10] = -1000;
                                            }
                                            else
                                            {
                                                logic.umnozhator(tag % 10, tag / 10);
                                            }
                                            flagcount -= 1;
                                        }
                                    }
                                }
                                else
                                {
                                    if (flagcount < allah)
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
                                            if (logic.gr[tag % 10, tag / 10] == -1000)
                                            {
                                                logic.gr[tag % 10, tag / 10] = 0;
                                            }
                                            else
                                            {
                                                logic.umnozhator(tag % 10, tag / 10);
                                            }
                                            flagcount += 1;
                                        }
                                    }
                                }

                            }

                        }
                    }
                    if (winer == allah)
                    {
                        Trimer.Stop();
                        Timer.Stop();
                        ImageBrush ib2 = new ImageBrush();
                        ib2.ImageSource = lico4;
                        umnozigifashizm.Background = ib2;
                        scores scor = new scores(score, (min * 60) + sec);
                        scor.Owner = this;
                        scor.Show();
                        winer = 0;
                        gridыч = false;
                        boomer.IsReadOnly = false;
                        startbutton = false;
                        umnozigifashizm.Foreground = Brushes.White;
                        umnozigifashizm.IsEnabled = true;
                        boomer.IsReadOnly = false;
                        startbutton = false;
                        umnozigifashizm.Foreground = Brushes.White;
                        gridыч = false;
                        gameplayed = true;
                    }
                }

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (startbutton == false)
            {
                Trimer.Stop();
                ImageBrush ib1 = new ImageBrush();

                ib1.ImageSource = lico3;
                umnozigifashizm.Background = ib1;
                Tumer.Start();
                try
                {
                    if (Convert.ToInt32(boomer.Text) > 0 && Convert.ToInt32(boomer.Text) < 51)
                    {
                        allah = Convert.ToInt32(boomer.Text);
                        labradoryc.Content = "     0:00";
                        sec = 0;
                        min = 0;
                        gridyc.Children.Clear();
                        gridyc.IsEnabled = true;
                        gridyc.Rows = 10;
                        gridyc.Columns = 10;
                        gridyc.Margin = new Thickness(0, 0, 10, 85);
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
                        suker.Content = " 00000";
                        labradoryc.Content = " 00:00";
                        boomer.IsReadOnly = true;
                        umnozigifashizm.Foreground = Brushes.Crimson;
                        startbutton = true;
                        gridыч = true;
                        cancheat = false;
                        cheatopened = false;
                        gameplayed = false;
                    }
                    else
                        MessageBox.Show("Мин должно быть больше 0 и меньше 51!");
                }
                catch { MessageBox.Show("Пиши циферки"); };

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
                umnozigifashizm.Foreground = Brushes.Red;
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
                if (mineheker == false)
                    ((Button)sender).Cursor = Cursors.Cross;
                else
                    ((Button)sender).Cursor = Cursors.Help;
            }
        }

        private void But_MouseLeave(object sender, RoutedEventArgs e)
        {
            if (gridыч == true)
            {
                ((Button)sender).BorderBrush = Brushes.Blue;
            }
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.I)
            {
                if (cheater == 0)
                    cheater++;
                else
                    cheater = 0;
            }
            else
            if (e.Key == Key.M)
            {
                if (cheater == 1)
                    cheater++;
                else
                    cheater = 0;
            }
            else
            if (e.Key == Key.S)
            {
                if (cheater == 2)
                    cheater++;
                else
                    cheater = 0;
            }
            else
            if (e.Key == Key.U)
            {
                if (cheater == 3)
                    cheater++;
                else
                    cheater = 0;
            }
            else
            if (e.Key == Key.C)
            {
                if (cheater == 4)
                    cheater++;
                else
                    cheater = 0;
            }
            else
            if (e.Key == Key.K)
            {
                if (cheater == 5)
                {
                    if (cheatopened == false)
                    {
                        if (cancheat == true)
                        {
                            cheatopened = true;
                            imsucc suc = new imsucc(massivich);
                            suc.Owner = this;
                            suc.Show();
                        }
                    }
                }
                else
                    cheater = 0;
            }
        }
        private void Player_MediaEnded(object sender, EventArgs e)
        {
            player.Stop();

        }

        private void MinePlayer_MediaEnded(object sender, EventArgs e)
        {
            mineplayer.Stop();
            tromb.Play();

        }
        private void Magic_MediaEnded(object sender, EventArgs e)
        {
            magic.Stop();

        }

        private void dispatcherTumer_Tick(object sender, EventArgs e)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = lico;
            pipecc++;
            if(pipecc == 1)
            {
                licoint = 0;
                Trimer.Start();
                umnozigifashizm.Background = ib;
                Tumer.Stop();
                pipecc = 0;
            }
        }

        private void Tromb_MediaEnded(object sender, EventArgs e)
        {
            tromb.Stop();

        }

        private void Spravka_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1.Введите количество мин \n2.Нажмите на лицо.\n3.Игра начинается только тогда, когда выбрана бомба.\n4.Нажми на любую клетку, чтобы начать игру.\n5.Чтобы победить, поставь флажки на все мины.\n6.Чтобы ставить флажки, нажмите на бомбу.\n7.Чтобы выбирать клетки, нажми на флажок.\nС уважением, LеИinСКie DICKа_РИ(-87)", "Справка");
        }

        bool sss = true;

        private void Pi_Click(object sender, RoutedEventArgs e)
        {
            wiw.Owner = this;

            squilt.info.Clear();
            wiw.somegrid.Items.Refresh();
            squilt.info = squilt.output();
            wiw.somegrid.Items.Refresh();
            wiw.loh++;
            if (sss==true)
            {
                sss = false;
                wiw.Show();
            }
            else
            if (sss==false)
            {
                sss = true;
                wiw.Hide();
                
                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            wiw.Show();
            wiw.Hide();
            wiw.Close();
            
        }

        private void Pi_MouseEnter(object sender, MouseEventArgs e)
        {
            pi.BorderBrush = Brushes.Red;
            pi.BorderThickness = new Thickness(2);
        }

        private void Pi_MouseLeave(object sender, MouseEventArgs e)
        {
            pi.BorderBrush = null;
            pi.BorderThickness = new Thickness(2);
        }

        private void Spravka_MouseEnter(object sender, MouseEventArgs e)
        {

            spravka.BorderBrush = Brushes.Red;
            spravka.BorderThickness = new Thickness(2);
        }

        private void Spravka_MouseLeave(object sender, MouseEventArgs e)
        {
            spravka.BorderBrush = null;
            spravka.BorderThickness = new Thickness(2);
        }

        private void dispatcherTrimer_Tick(object sender, EventArgs e)
        {
            ImageBrush ib = new ImageBrush();
            ib.ImageSource = lico;
            ImageBrush ib1 = new ImageBrush();
            ib1.ImageSource = lico1;
            ImageBrush ib2 = new ImageBrush();
            ib2.ImageSource = lico2;
            licoint++;
            switch (licoint)
            {
                case 1:
                    {
                        umnozigifashizm.Background = ib;
                        break;
                    }
                case 2:
                    {
                        umnozigifashizm.Background = ib1;
                        break;
                    }
                case 3:
                    {
                        umnozigifashizm.Background = ib;
                        break;
                    }
                case 4:
                    {
                        umnozigifashizm.Background = ib2;
                        licoint = 0;
                        break;
                    }
            }
        }
    }
}
