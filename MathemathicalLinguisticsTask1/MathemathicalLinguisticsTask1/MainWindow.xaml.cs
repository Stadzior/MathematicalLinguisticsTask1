using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MathemathicalLinguisticsTask1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ParkingMeter ParkingMeter { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ParkingMeter = Application.Current.Resources["parkingMeter"] as ParkingMeter;
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
            ParkingMeter.InsertCoin((double)e.Data.GetData(typeof(double)));
        }

    }
}
