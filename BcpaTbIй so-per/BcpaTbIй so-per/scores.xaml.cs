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
        string db_name = @"C:\Users\Сергей\Desktop\kursovaya\BcpaTbIй so-per\hightscores.db";

        public class data
        {
            public int uid { get; set; }
            public string name { get; set; }
            public int time { get; set; }
            public int highscore { get; set; }
        }
        List<data> info = new List<data>();




        public int scures = 0;
        public int tumes = 0;
        public scores(int score, int time)
        {
            InitializeComponent();
            scures = score;
            tumes = time;
            win_name.MaxLength = 11;
            somegrid.IsReadOnly = true;

            shower();

        }

        public void shower()
        {
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source= " + db_name + ";Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM full ORDER BY scores DESC";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                data st = new data
                {
                    name = reader["name"].ToString(),
                    time = int.Parse(reader["time"].ToString()),
                    highscore = int.Parse(reader["scores"].ToString()),
                    uid = int.Parse(reader["uid"].ToString())
                };
                info.Add(st);

            }
            somegrid.ItemsSource = info;
            somegrid.Items.Refresh();
            m_dbConnection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            qqq.IsEnabled = false;
            bool make_add = true;
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source= " + db_name + ";Version=3;");
            m_dbConnection.Open();
            string sql = "select name from full";
            SQLiteCommand command1 = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                if (reader["name"].ToString() == win_name.Text)
                {
                    extremebanner bane = new extremebanner(win_name.Text);
                    bane.Owner = this;
                    if (bane.ShowDialog() == true)
                    {
                        sql = "UPDATE full SET scores = " + scures + " WHERE name = '" + win_name.Text + "'; " + " UPDATE full SET time = " + tumes + " WHERE name = '" + win_name.Text + "'";
                        command1 = new SQLiteCommand(sql, m_dbConnection);
                        command1.ExecuteNonQuery();
                        make_add = false;
                    }
                    // иначе оставляем результат из таблицы
                }
            }


            if (make_add == true)
            {
                SQLiteCommand command = new SQLiteCommand();
                sql = "INSERT INTO  full ( name, scores, time ) VALUES (" + "'" + win_name.Text + "'" + "," + scures + "," + tumes + ")";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }


            m_dbConnection.Close();
            info.Clear();
            shower();
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
    }
}
