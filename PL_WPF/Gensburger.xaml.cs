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
using BL;
using DAL;
using BE;

namespace PL_WPF
{
    /// <summary>
    /// Interaction logic for Gensburger.xaml
    /// </summary>
    public partial class Gensburger : Window
    {
        public Gensburger()
        {
            InitializeComponent();
            this.Show();
            this.TraineesCbx.ItemsSource = FactoryDAL.getInstance().GetTrainees();
            TraineesCbx.DisplayMemberPath = "ID";
        }
        private void TraineesCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Address traineeAddress = (TraineesCbx.SelectedItem as Trainee).Address;
            TestersCbx.DisplayMemberPath = "Name";
            TestersCbx.Visibility = Visibility.Visible;
            TestersCbx.Items.Clear();

            //FactoryDAL.getInstance().distance(traineeAddress, Backgroundworker_RunWorkerCompleted);

            TestersCbx.DisplayMemberPath = "Name";
            TestersCbx.Visibility = Visibility.Visible;

        }

        /*private void Backgroundworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Tester result = (Tester)e.Result;
                if (result != null)
                {
                    TestersCbx.Items.Add(result);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/

        private void TrainerCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
