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
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Window
    {
        public HomePage()
        {
            InitializeComponent();
        }

        //Trainees
        private void AddTraineeButton(object sender, RoutedEventArgs e)
        {
            AddTrainee addTrainee = new AddTrainee();
            addTrainee.Show();

        }
        private void UpdateTraineeButton(object sender, RoutedEventArgs e)
        {
            //to do
        }

        private void DeleteTraineeButton(object sender, RoutedEventArgs e)
        {
            DeleteTrainee deleteTrainee = new DeleteTrainee();
            deleteTrainee.Show();
        }

        //Testers
        private void AddTesterButton(object sender, RoutedEventArgs e)
        {
            AddTester addTester = new AddTester(); //create instance of the window
            addTester.Show(); //open the window
        }

        private void UpdateTesterButton(object sender, RoutedEventArgs e)
        {
            UpdateTester updateTester = new UpdateTester();
            updateTester.Show();
        }

        private void DeleteTesterButton(object sender, RoutedEventArgs e)
        {
            DeleteTester deletetester = new DeleteTester();//create instance of the window
            deletetester.Show(); //open the window                
        }

        private void AddTestButton(object sender, RoutedEventArgs e)
        {
            AddTest addTest = new AddTest();
            addTest.Show();
        }

        private void DeleteTestButton(object sender, RoutedEventArgs e)
        {
            DeleteTest deleteTest = new DeleteTest();
            deleteTest.Show();
        }

        private void UpdateTestButton(object sender, RoutedEventArgs e)
        {
            UpdateTest updateTest = new UpdateTest();
            updateTest.Show();
        }
    }
}
