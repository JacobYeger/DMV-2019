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
            Trainee trainee = new Trainee();
            trainee.ID = iDTextBox.Text;
            trainee.FirstName = firstNameTextBox.Text;
            trainee.LastName = lastNameTextBox.Text;
            trainee.Birthday = birthdayDatePicker.SelectedDate.Value.Date;
            //email
            MailAddress email = new MailAddress(EmailTextBox.Text);
            trainee.Email =  email;
            String city = cityTextBox.Text;
            String street = streetTextBox.Text;
            int number = int.Parse(numberTextBox.Text);
            trainee.Address = new Address
            {
                Number = number,
                Street = street,
                City = city
            };
            trainee.Gender = (Gender)genderComboBox.SelectedItem;
            trainee.PhoneNumber = phoneNumberTextBox.Text;
            //Trainee-specific stuff
            trainee.VehicleType = (VehicleType)vehicleComboBox.SelectedItem;
            trainee.Gearbox = (Gearbox)gearboxComboBox.SelectedItem;
            trainee.DrivingSchool = (DrivingSchool)drivingSchoolComboBox.SelectedItem;
            trainee.DrivingInstructor = drivingInstructorTextBox.Text;
            trainee.NumDrivingLessonsPassed = int.Parse(numDrivingLessonsPassedTextBox.Text);
            Console.WriteLine(trainee);
            //add trainee
            Dal_imp dal_Imp = new Dal_imp();
            dal_Imp.UpdateTrainee(trainee);
            Console.WriteLine(dal_Imp.GetTrainees()); 
            this.Close();

        }
    }
}
