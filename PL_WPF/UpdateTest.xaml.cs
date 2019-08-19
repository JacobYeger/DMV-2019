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
    /// Interaction logic for UpdateTest.xaml
    /// </summary>
    public partial class UpdateTest : Window
    {
        public UpdateTest()
        {
            InitializeComponent();
        }

        private void finish(object sender, RoutedEventArgs e)
        {
            Test test = new Test();
            
            test.TestNumber = TestNumberTextBox.Text;
            //will set the date and time for the test to the date which was selected and the time selected from the combo box
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
            myDAL md = new myDAL();
            md.UpdateDrivingTest(test);
            Console.WriteLine(test.TestTime);

            this.Close();
        }
    }
}
