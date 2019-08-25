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
using DAL;

namespace PL_WPF
{
    /// <summary>
    /// Interaction logic for DeleteTrainee.xaml
    /// </summary>
    public partial class DeleteTrainee : Window
    {
        public DeleteTrainee()
        {
            InitializeComponent();
        }

        private void PromptAuthorization(object sender, RoutedEventArgs e)
        {
            myDAL md = new myDAL();
            try
            {
                Trainee trainee = new Trainee();
                trainee.ID = DeleteIDTextbox.Text;
                bool close = md.RemoveTrainee(trainee);
            
                if (close)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The trainee does not exist in the system");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            /*
            List<Trainee> Lst = md.GetTrainees();
            foreach (Trainee trne in Lst)
            {
                Console.WriteLine(trne);
            }
            */
        }
    }
}
