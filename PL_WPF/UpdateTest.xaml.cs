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
using BL;

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
            bool flag = true;

            //Test number
            if(TestNumberTextBox.Text.Equals(String.Empty))
            {
                MessageBox.Show("Test number feild is required");
                flag = false;
            }
            else
            {
                test.TestNumber = TestNumberTextBox.Text;
            }

            //Sets the date if anything if in the box, leaves it alone otherwise
            if (testDateDatePicker.SelectedDate == null)
            {
                //Sentinel value
                test.TestDate = new DateTime();
            }
            else
            {
                test.TestDate = testDateDatePicker.SelectedDate.Value.Date;
            }

            //will set the date and time for the test to the date which was selected and the time selected from the combo box
            if(TestTimePicker.SelectedIndex == -1)
            {
                //Sentinel value
                test.TestTime = new DateTime();
            }
            else
            {
                test.TestTime = Convert.ToDateTime(testDateDatePicker.SelectedDate.Value.ToShortDateString() + " " + TestTimePicker.SelectedValue.ToString());
            }

            //Trainee number
            if(traineeIdNumberTextBox.Text.Equals(String.Empty))
            {
                test.TraineeIdNumber = "empty";
            }
            else
            {
                test.TraineeIdNumber = traineeIdNumberTextBox.Text;
            }

            //Tester number
            if(testerIdNumberTextBox.Text.Equals(String.Empty))
            {
                test.TesterIdNumber = "empty";
            }
            else
            {
                test.TesterIdNumber = testerIdNumberTextBox.Text;
            }

            //Address
            int number;
            if(numberTextBox.Text.Equals(String.Empty))
            {
                //Sentinel value
                number = 0;
            }
            else
            {
                try
                {
                    number = int.Parse(numberTextBox.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Please only enter numbers in the address number field");
                    flag = false;
                }
            }
            //If anything at all was entered in one of the address fields
            if(!(cityTextBox.Text.Equals(String.Empty) && streetTextBox.Text.Equals(String.Empty) && numberTextBox.Text.Equals(String.Empty)))
            {
                test.TestStartPoint = new Address
                {
                    City = cityTextBox.Text,
                    Number = number,
                    Street = streetTextBox.Text
                };
            }
            else
            {
                //Sentinel values
                test.TestStartPoint = new Address
                {
                    City = "empty",
                    Number = 0,
                    Street = "empty"
                };
            }

            //Maintaining distance
            test.MaintainingDistance = maintainingDistanceCheckBox.IsChecked;
            //Mirror Checking
            test.MirrorChecking = mirrorCheckingCheckBox.IsChecked;
            //Parking in reverse (parallel parking?)
            test.ParkingInReverse = parkingInReverseCheckBox.IsChecked;
            //Signaling
            test.Signaling = signalingCheckBox.IsChecked;
            
            myBL mb = new myBL();
            mb.UpdateDrivingTest(test);

            if(flag)
            {
                this.Close();
            }
        }
    }
}
