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

namespace PL_WPF
{
    /// <summary>
    /// Interaction logic for CreateTraineeWnd.xaml
    /// </summary>
    public partial class CreateTraineeWnd : Window
    {
        private BE.Trainee trainee;
        public CreateTraineeWnd()
        {
            InitializeComponent();
            trainee = new BE.Trainee
            {
                ID = "1234"
            };
            this.DataContext = trainee;
        }

        private void ConfirmBtn_Click(object sender, RoutedEventArgs e)
        {
            trainee = new BE.Trainee
            {
                ID = iDTextBox.Text,
                Birthday =(DateTime)birthDayDatePicker.SelectedDate,
                //DrivingSchool = drivingSchoolTextBox.Text,







                //rest of details
                


            };
        }
        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource traineeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("traineeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // traineeViewSource.Source = [generic data source]
           // System.Windows.Data.CollectionViewSource traineeViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("traineeViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // traineeViewSource.Source = [generic data source]
        }

        private void TraineeDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
