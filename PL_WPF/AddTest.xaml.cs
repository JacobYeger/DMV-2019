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
            bool flag = true;
            //string TestTime = TestTimePicker.SelectedValue.ToString();
            //Console.WriteLine(TestTime);

            //will set the date and time for the test to the date which was selected and the time selected from the combo box
            if (testDateDatePicker == null)
            {
                MessageBox.Show("Must select a test date");
                flag = false;
            }
            else
            {
                test.TestDate = testDateDatePicker.SelectedDate.Value.Date;
            }


            if (TestTimePicker.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a test time");
                flag = false;
            }

            test.TestTime = Convert.ToDateTime(testDateDatePicker.SelectedDate.Value.ToShortDateString() + " " + TestTimePicker.SelectedValue.ToString());

            if (cityTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter city");
                flag = false;
            }
            String city = cityTextBox.Text;

            if (streetTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter a street");
                flag = false;
            }
            String street = streetTextBox.Text;

            if (numberTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter number");
                flag = false;
            }
            int number = int.Parse(numberTextBox.Text);
            test.TestStartPoint = new Address
            {
                City = city,
                Number = number,
                Street = street
            };

            myDAL md = new myDAL();
            flag = md.AddDrivingTest(test);
            Console.WriteLine(test.TestTime);
            if (flag)
                MessageBox.Show("The Date of your test is: " + test.TestTime.ToShortDateString() + Environment.NewLine + "The time of your test is: " + test.TestTime.ToShortTimeString() + Environment.NewLine + "Your tester number is: " + Environment.NewLine + Configuration.CurrentTestNumber);

            this.Close();
        }
    }
}