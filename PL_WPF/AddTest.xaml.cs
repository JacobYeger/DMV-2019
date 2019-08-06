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
using BE;
using DAL;

namespace PL_WPF
{
    /// <summary>
    /// Interaction logic for AddTest.xaml
    /// </summary>
    public partial class AddTest : Window
    {
        public AddTest()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource testViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("testViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // testViewSource.Source = [generic data source]
        }

        private void finish(object sender, RoutedEventArgs e)
        {
            Test test = new Test();
            //string TestTime = TestTimePicker.SelectedValue.ToString();
            //Console.WriteLine(TestTime);
            test.TestTime = Convert.ToDateTime(testDateDatePicker.SelectedDate.Value.ToShortDateString() + " " + TestTimePicker.SelectedValue.ToString());
            test.TestStartPoint = new Address
            {
                City = cityTextBox.Text,
                Number = int.Parse(numberTextBox.Text),
                Street = streetTextBox.Text               
            };
            test.MaintainingDistance = maintainingDistanceCheckBox.IsChecked == true;
            test.MirrorChecking = mirrorCheckingCheckBox.IsChecked == true;
            test.ParkingInReverse = parkingInReverseCheckBox.IsChecked == true;
            test.Signaling = signalingCheckBox.IsChecked == true;
            test.TestDate = testDateDatePicker.SelectedDate.Value.Date;
            
            Console.WriteLine(test.TestTime);
        }
    }
}
