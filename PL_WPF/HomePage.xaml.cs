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
            this.Closed += HomePage_Closing;
        }

        //Trainees
        private void AddTraineeButton(object sender, RoutedEventArgs e)
        {
            AddTrainee addTrainee = new AddTrainee();
            addTrainee.Show();

        }
        private void UpdateTraineeButton(object sender, RoutedEventArgs e)
        {
            UpdateTrainee updateTrainee = new UpdateTrainee();
            updateTrainee.Show();
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

        private void HomePage_Closing(object sender, EventArgs e)
        {
            DAL.myDAL md = new DAL.myDAL();
            System.Diagnostics.Debug.WriteLine("--------------------------------------");

            //Testers
            System.Diagnostics.Debug.WriteLine("Testers: ");
            IEnumerable<Tester> testers = md.GetTesters();
            foreach (Tester tester in testers)
            {
                System.Diagnostics.Debug.WriteLine(tester);
            }

            //Trainees
            System.Diagnostics.Debug.WriteLine("Trainees: ");
            IEnumerable<Trainee> trainees = md.GetTrainees();
            foreach (Trainee trainee in trainees)
            {
                System.Diagnostics.Debug.WriteLine(trainee);
            }

            //Tests
            System.Diagnostics.Debug.WriteLine("Tests: ");
            IEnumerable<Test> tests = md.GetDrivingTests();
            foreach (Test test in tests)
            {
                System.Diagnostics.Debug.WriteLine(test);
            }
            

        }

    }
}
