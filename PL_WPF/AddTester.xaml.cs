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
    /// Interaction logic for AddTester.xaml
    /// </summary>
    public partial class AddTester : Window
    {
        public AddTester()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource testerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("testerViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // testerViewSource.Source = [generic data source]
        }

        private void Finish(object sender, RoutedEventArgs e)
        {
            Tester tester = new Tester();
            tester.ID = iDTextBox.Text;
            


            
            tester.FirstName = firstNameTextBox.Text;
            tester.LastName = lastNameTextBox.Text;
            tester.Birthday = birthdayDatePicker.SelectedDate.Value.Date;
            //email
            String city = cityTextBox.Text;
            String street = streetTextBox.Text;
            int number = Int32.Parse(numberTextBox.Text);
            tester.Address = new Address
            {
                Number = number,
                Street = street,
                City = city
            };
            tester.Gender = (Gender)genderComboBox.SelectedItem;
            tester.PhoneNumber = phoneNumberTextBox.Text;
            //Trainee-specific stuff
            tester.VehicleSpecialize = (VehicleType)vehicleSpcializeComboBox.SelectedItem;
            tester.MAX_TESTS_PER_WEEK = int.Parse(MAX_TESTS_PER_WEEKTextBox.Text);
            Console.WriteLine(tester);
            this.Close();
        }
    }
}
