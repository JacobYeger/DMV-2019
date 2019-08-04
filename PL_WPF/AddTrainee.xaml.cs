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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

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
            trainee.ID = iDTextBox.Text;
            trainee.FirstName = firstNameTextBox.Text;
            trainee.LastName = lastNameTextBox.Text;
            trainee.Birthday = birthdayDatePicker.SelectedDate.Value.Date;
            //email
            String city = cityTextBox.Text;
            String street = streetTextBox.Text;
            int number = Int32.Parse(numberTextBox.Text);
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
            trainee.NumDrivingLessonsPassed = Int32.Parse(numDrivingLessonsPassedTextBox.Text);
            Console.WriteLine(trainee);
            this.Close();
        }        
    }
}
