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
            //Sentinel values
            string city = "empty";
            int number = 0;
            string street = "empty";

             if(!cityTextBox.Text.Equals(String.Empty))
            {
                city = cityTextBox.Text;
            }
            
            if(!streetTextBox.Text.Equals(String.Empty))
            {
                street = streetTextBox.Text;
            }

            if(!numberTextBox.Text.Equals(String.Empty))
            {
                try
                {
                    number = int.Parse(numberTextBox.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Number field" + ex.Message);
                    flag = false;
                }
            }

            test.TestStartPoint = new Address
            {
                City = city,
                Number = number,
                Street = street
            };

            //Maintaining distance
            test.MaintainingDistance = (bool)maintainingDistanceCheckBox.IsChecked;
            //Mirror Checking
            test.MirrorChecking = (bool)mirrorCheckingCheckBox.IsChecked;
            //Parking in reverse (parallel parking?)
            test.ParkingInReverse = (bool)parkingInReverseCheckBox.IsChecked;
            //Signaling
            test.Signaling = (bool)signalingCheckBox.IsChecked;

            if(testResultTextBox.Text.Equals(String.Empty))
            {
                MessageBox.Show("Must enter test result");
                flag = false;
            }
            else
            {
                try
                {
                    test.TestScore = int.Parse(testResultTextBox.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Test result: " + ex.Message);
                    flag = false;
                }
            }

            test.TestersComments = testersCommentsTextBox.Text;
            
            myBL mb = new myBL();

            if(flag)
            {
                try
                {
                    mb.UpdateDrivingTest(test);
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
