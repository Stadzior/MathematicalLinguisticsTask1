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

namespace MathemathicalLinguisticsTask1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ParkingMeter _parkingMeter;

        public MainWindow()
        {
            InitializeComponent();
            _parkingMeter = new ParkingMeter();
        }

        private void imageOnePLN_MouseMove(object sender, MouseEventArgs e)
            => coin_MouseMove(sender, e, 1.00);
     
        private void imageTwoPLN_MouseMove(object sender, MouseEventArgs e)
            => coin_MouseMove(sender, e, 2.00);

        private void imageFivePLN_MouseMove(object sender, MouseEventArgs e)
            => coin_MouseMove(sender, e, 5.00);

        private void coin_MouseMove(object sender, MouseEventArgs e, double value)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragDrop.DoDragDrop(sender as Image, value, DragDropEffects.Copy);
        }

        private void textBlockInsert_Drop(object sender, DragEventArgs e)
        {
            _parkingMeter.InsertCoin((double)e.Data.GetData(typeof(double)));
            textBoxDisplay.Text = string.Format("{0:N2}", _parkingMeter.InsertedValue);
        }

    }
}
