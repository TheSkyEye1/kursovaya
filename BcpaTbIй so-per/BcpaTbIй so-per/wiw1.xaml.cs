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
        public bool krinje = false;
        public int loh = 0;
        public wiw1()
        {
            InitializeComponent();
            somegrid.ItemsSource = sqlite.output();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(loh == 0)
            {
                e.Cancel = false;
            }
            if (Visibility == Visibility.Hidden)
            {

                e.Cancel = false;

            }
            else
                e.Cancel = true;
        }

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                //MessageBox.Show("oh hi");
                sqlite.info.Clear();
                somegrid.ItemsSource = sqlite.output();
                somegrid.Items.Refresh();
            }
        }
    }
}
