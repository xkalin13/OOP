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

namespace WpfApp1
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceReference1.Service1Client sluzba = new ServiceReference1.Service1Client();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vysledek.Content = sluzba.Spocti(decimal.Parse(txtbx1.Text), decimal.Parse(txtbx2.Text), operator1.Text);
        }
    }
}
