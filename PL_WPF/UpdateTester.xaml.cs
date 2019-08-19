using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for UpdateTester.xaml
    /// </summary>
    public partial class UpdateTester : Window
    {
        public UpdateTester()
        {
            InitializeComponent();
        }

        private void finish(object sender, RoutedEventArgs e)
        {
            Tester tester = new Tester();
            tester.ID = iDTextBox.Text;




            tester.FirstName = firstNameTextBox.Text;
            tester.LastName = lastNameTextBox.Text;
            tester.Birthday = birthdayDatePicker.SelectedDate.Value.Date;
            //email
            MailAddress email = new MailAddress(EmailTextBox.Text);
            tester.Email = email;
            String city = cityTextBox.Text;
            String street = streetTextBox.Text;
            int number = int.Parse(numberTextBox.Text);
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

            //update the tester
            myDAL md = new myDAL();
            md.UpdateTester(tester);
            //Console.WriteLine(tester);
            this.Close();
        }
    }
}
