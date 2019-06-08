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
    /// Логика взаимодействия для extremebanner.xaml
    /// </summary>
    public partial class extremebanner : Window
    {
        public extremebanner(string name)
        {
            InitializeComponent();
          messss.Content = "Имя " + name + " уже есть в таблице. Заменить его?";
        }

        private void Da_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Pizda_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
