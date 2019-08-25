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
using BE;
using BL;
using DAL;

namespace PL_WPF
{
    /// <summary>
    /// Interaction logic for UpdateTrainee.xaml
    /// </summary>
    public partial class UpdateTrainee : Window
    {
        public UpdateTrainee()
        {
            InitializeComponent();
        }

        private void finish(object sender, RoutedEventArgs e)
        {
            myBL mb = new myBL();
            Trainee trainee = new Trainee();
            bool flag = true;

            string city = "";
            string street =  "";
            int number = 0;

            //Birthday
            if (birthdayDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Must select a birthday");
                flag = false;
            }
            else
            {
                trainee.Birthday = birthdayDatePicker.SelectedDate.Value.Date;
            }

            //first name
            if (firstNameTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter a first name");
                flag = false;
            }
            else
            {
                trainee.FirstName = firstNameTextBox.Text;
            }

            //Last name
            if (lastNameTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter a last name");
                flag = false;
            }
            else
            {
                trainee.LastName = lastNameTextBox.Text;
            }

            //ID
            if (iDTextBox.Text.Equals(String.Empty))
            {
                MessageBox.Show("Must enter ID number");
                flag = false;
            }
            else
            {
                try
                {
                    trainee.ID = iDTextBox.Text;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            //Gender
            if (genderComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a gender");
                flag = false;
            }
            else
            { 
                trainee.Gender = (Gender)genderComboBox.SelectedItem;
            }

            //Phone number
            if (phoneNumberTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter a phone number");
                flag = false;
            }
            else
            {
                trainee.PhoneNumber = phoneNumberTextBox.Text;
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

            trainee.Address = new Address
            {
                Number = number,
                Street = street,
                City = city
            };

            //Email
            if (EmailTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter email");
                flag = false;
            }
            else
            { 
                try
                {
                    MailAddress email = new MailAddress(EmailTextBox.Text);
                    trainee.Email = email;
                }
                catch(Exception ex)
                {
                    flag = false;
                    MessageBox.Show(ex.Message);
                }
            }
            
            //Trainee-specific stuff
            //Driving school
            if (drivingSchoolComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a driving school");
                flag = false;
            }
            else
            { 
                trainee.DrivingSchool = (DrivingSchool)drivingSchoolComboBox.SelectedItem;
            }

            //Driving instructor
            if (drivingInstructorTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter driving instructor");
                flag = false;
            }
            else
            {
                trainee.DrivingInstructor = drivingInstructorTextBox.Text;
            }

            //Number of driving lessons passed
            if (numDrivingLessonsPassedTextBox.Text.Equals(string.Empty))
            {
                MessageBox.Show("Must enter number of driving tests passed");
                flag = false;
            }
            else
            {
                try
                {
                    trainee.NumDrivingLessonsPassed = int.Parse(numDrivingLessonsPassedTextBox.Text);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    flag = false;
                }
            }

            //Gearbox
            if (gearboxComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a gearbox");
                flag = false;
            }
            else
            { 
                trainee.Gearbox = (Gearbox)gearboxComboBox.SelectedItem;
            }

            //Vehicle type
            if (vehicleComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a vehicle type");
                flag = false;
            }
            else
            { 
                trainee.VehicleType = (VehicleType)vehicleComboBox.SelectedItem;
            }
            
            
            System.Diagnostics.Debug.WriteLine(trainee);
            //add trainee
            //mb.AddTrainee(trainee);
            System.Diagnostics.Debug.WriteLine("meep morp");
            System.Diagnostics.Debug.WriteLine(mb.GetTrainees());
            if (flag)
            {
                try
                {
                    mb.UpdateTrainee(trainee);
                }
                catch(Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
                this.Close();
            }
            
        }
    }
}
