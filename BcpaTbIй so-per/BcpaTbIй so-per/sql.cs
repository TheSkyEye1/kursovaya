using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BcpaTbIй_so_per
{
    class sql
    {
        string db_name = @"C:\Users\Сергей\Desktop\kursovaya\BcpaTbIй so-per\hightscores.db";
        public class data
        {
            public int uid { get; set; }
            public string name { get; set; }
            public int time { get; set; }
            public int highscore { get; set; }
        }
        List<data> spisok = new List<data>();
        List<data> info = new List<data>();
        public int tumes = 0;

        public List<data> output()
        {
            info.Clear();
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source= " + db_name + ";Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM full ORDER BY time DESC";
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
            m_dbConnection.Close();
            return (info);
        }
        
        
        public bool input(int scures,int tumes, string win_name)
        {
           // extremebanner bane = new extremebanner(win_name);
          //  bane.Owner = scores.GetWindow();
            bool make_add = true;
            SQLiteConnection m_dbConnection;
            m_dbConnection = new SQLiteConnection("Data Source= " + db_name + ";Version=3;");
            m_dbConnection.Open();
            string sql = "select name from full";
            SQLiteCommand command1 = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                if (reader["name"].ToString() == win_name)
                {

                    if ((MessageBox.Show("Имя уже есть в таблице. Заменить?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                    {
                        sql = "UPDATE full SET scores = " + scures + " WHERE name = '" + win_name + "'; " + " UPDATE full SET time = " + tumes + " WHERE name = '" + win_name + "'";
                        command1 = new SQLiteCommand(sql, m_dbConnection);
                        command1.ExecuteNonQuery();
                        make_add = false;
                    }
                    else
                        make_add = false;
                    // иначе оставляем результат из таблицы
                }
            }


            if (make_add == true)
            {
                SQLiteCommand command = new SQLiteCommand();
                sql = "INSERT INTO  full ( name, scores, time ) VALUES (" + "'" + win_name + "'" + "," + scures + "," + tumes + ")";
                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();
            }


            m_dbConnection.Close();
            info.Clear();
            return true;
        }
    }
}
