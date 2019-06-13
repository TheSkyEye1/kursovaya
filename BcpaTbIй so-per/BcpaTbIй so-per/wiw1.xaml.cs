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
    /// Логика взаимодействия для wiw1.xaml
    /// </summary>
    public partial class wiw1 : Window
    {
        sql sqlite =  new sql();
        public wiw1()
        {
            InitializeComponent();
            somegrid.ItemsSource = sqlite.output();
        }
    }
}
