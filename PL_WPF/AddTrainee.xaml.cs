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
using System.Net.Mail;
using DAL;
using BE;

namespace PL_WPF
{
    /// <summary>
    /// Interaction logic for AddTrainee.xaml
    /// </summary>
    public partial class AddTrainee : Window
    {
        public AddTrainee()
        {
            InitializeComponent();
            this.DataContext = this;
        }

         private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource traineeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("traineeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // traineeViewSource.Source = [generic data source]
        }

        private void finish(object sender, RoutedEventArgs e)
        {
            Trainee trainee = new Trainee();
            bool flag = true;
            trainee.ID = iDTextBox.Text;
            trainee.FirstName = firstNameTextBox.Text;
            trainee.LastName = lastNameTextBox.Text;
            trainee.Birthday = birthdayDatePicker.SelectedDate.Value.Date;
           
           

            if (iDTextBox.Text.Equals(String.Empty))
            {
                MessageBox.Show("Must enter ID number");
                flag = false;
            }
            else
            {
                trainee.ID = iDTextBox.Text;
            }

            if (firstNameTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter a first name");
                flag = false;
            }
            trainee.FirstName = firstNameTextBox.Text;

            if (lastNameTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter last name");
                flag = false;
            }
            trainee.LastName = lastNameTextBox.Text;
            if(birthdayDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Must enter  birthday");
                flag = false;
            }
            trainee.Birthday = birthdayDatePicker.SelectedDate.Value.Date;

            //email
            if (EmailTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter email");
                flag = false;
            }
            MailAddress email = new MailAddress(EmailTextBox.Text);

            trainee.Email = email;

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

            trainee.Address = new Address
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
            trainee.Gender = (Gender)genderComboBox.SelectedItem;

            if (phoneNumberTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter a phone number");
                flag = false;
            }
            trainee.PhoneNumber = phoneNumberTextBox.Text;



            //Trainee-specific stuff
            if(vehicleComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a vehicle type");
                flag = false;
            }
            trainee.VehicleType = (VehicleType)vehicleComboBox.SelectedItem;
            if(gearboxComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a gearbox type");
                flag = false;
            }
            trainee.Gearbox = (Gearbox)gearboxComboBox.SelectedItem;
             
            trainee.DrivingSchool = (DrivingSchool)drivingSchoolComboBox.SelectedItem;
            trainee.DrivingInstructor = drivingInstructorTextBox.Text;
            trainee.NumDrivingLessonsPassed = int.Parse(numDrivingLessonsPassedTextBox.Text);
            Console.WriteLine(trainee);
            //add trainee
            myDAL md = new myDAL();
            md.AddTrainee(trainee);
            Console.WriteLine(md.GetTrainees());
            if (flag)
            {
                this.Close();
            }
            
        }        
    }
}
