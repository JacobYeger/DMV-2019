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
            bool flag = true;
            //string TestTime = TestTimePicker.SelectedValue.ToString();
            //Console.WriteLine(TestTime);

            string city = "";
            string street =  "";
            int number = 0;

            //Date
            //will set the date and time for the test to the date which was selected and the time selected from the combo box
            if (testDateDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Must select a test date");
                flag = false;
            }
            else
            {
                test.TestDate = testDateDatePicker.SelectedDate.Value.Date;
            }

            //Time
            if (TestTimePicker.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a test time");
                flag = false;
            }
            else
            {
                test.TestTime = Convert.ToDateTime(testDateDatePicker.SelectedDate.Value.ToShortDateString() + " " + TestTimePicker.SelectedValue.ToString());
            }

            //TraineeID
            if(traineeIdNumberTextBox.Text.Equals(String.Empty))
            {
                MessageBox.Show("Must enter the ID number of the trainee taking the test");
            }
            else
            {
                test.TraineeIdNumber = traineeIdNumberTextBox.Text;
            }

            //Address
            //City
            if (cityTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter city");
                flag = false;
            }
            else
            {
                city = cityTextBox.Text;
            }

            //Street
            if (streetTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter a street");
                flag = false;
            }
            else
            {
                street = streetTextBox.Text;
            }

            //Number
            if (numberTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter number");
                flag = false;
            }
            else
            {
                number = int.Parse(numberTextBox.Text);
            }

            test.TestStartPoint = new Address
            {
                Number = number,
                Street = street,
                City = city
            };

            myBL mb = new myBL();
            test.TestNumber = "0";
            if (flag)
            {
                try
                {
                    mb.AddDrivingTest(test);
                    MessageBox.Show("The Date of your test is: " + test.TestTime.ToShortDateString() + Environment.NewLine + "The time of your test is: " + test.TestTime.ToShortTimeString() + Environment.NewLine + "Your tester number is: " + Environment.NewLine + Configuration.CurrentTestNumber);
                    this.Close();
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
        }
    }
}