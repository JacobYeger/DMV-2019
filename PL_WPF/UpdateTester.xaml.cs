﻿using System;
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
using System.Net.Mail;

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
            Tester tester = new Tester(); //instantiate a tester 
            myDAL dal_Imp = new myDAL(); //create instance of dal implementation
            bool flag = true; //flag to ensure all fields have been filled

            if (iDTextBox.Text.Equals(String.Empty))
            {
                MessageBox.Show("Must enter ID number");
                flag = false;
            }
            else
            {
                tester.ID = iDTextBox.Text;
            }

            if (firstNameTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter a first name");
                flag = false;
            }
            tester.FirstName = firstNameTextBox.Text;

            if (lastNameTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter a last name");
                flag = false;
            }
            tester.LastName = lastNameTextBox.Text;

            if (birthdayDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Must select a birthday");
                flag = false;
            }
            tester.Birthday = birthdayDatePicker.SelectedDate.Value.Date;

            //email
            if (EmailTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter email");
                flag = false;
            }
            MailAddress email = new MailAddress(EmailTextBox.Text);

            tester.Email = email;

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

            tester.Address = new Address
            {
                Number = number,
                Street = street,
                City = city
            };

            if (genderComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a gender");
                flag = false;
            }
            tester.Gender = (Gender)genderComboBox.SelectedItem;

            if (phoneNumberTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter a phone number");
                flag = false;
            }
            tester.PhoneNumber = phoneNumberTextBox.Text;

            //Tester-specific stuff
            if (vehicleSpcializeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Must slect a vehicle to specialize");
                flag = false;
            }
            tester.VehicleSpecialize = (VehicleType)vehicleSpcializeComboBox.SelectedItem;
            if (MAX_TESTS_PER_WEEKTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter maximum tests per week");
                flag = false;
            }
            tester.MAX_TESTS_PER_WEEK = int.Parse(MAX_TESTS_PER_WEEKTextBox.Text);
            foreach (var item in Checkboxes.Children)
            {
                if (!(item is CheckBox))
                {
                    continue;
                }
                CheckBox checkbox = item as CheckBox;
                int i = Grid.GetColumn(checkbox) - 1;
                int j = Grid.GetRow(checkbox);
                tester.AvailabilityMatrix[i, j] = (bool)checkbox.IsChecked;

            }
            //try-catch to send the correct mesage to the user
            try
            {
                dal_Imp.AddTester(tester);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

            Console.WriteLine(tester);

            if (flag)
            {
                this.Close();
            }
        }
    }
}