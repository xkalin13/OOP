using System;
using System.Windows;
using System.Windows.Controls;


namespace cv9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calculator calculator = new Calculator();
        public MainWindow()
        {
            InitializeComponent();
            display.Text = calculator.Display;
            pamet.Text = calculator.Pamet;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            calculator.Tlacitko((sender as Button).Content.ToString());
            display.Text = calculator.Display;
            pamet.Text = calculator.Pamet;
            lastNumber.Text = calculator.lastNumber;
        }
    }
}
