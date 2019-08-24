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
    /// Interaction logic for DeleteTester.xaml
    /// </summary>
    public partial class DeleteTester : Window
    {
        public DeleteTester()
        {
            InitializeComponent();
        }

        private void PromptAuthorization(object sender, RoutedEventArgs e)
        {
            myDAL md = new myDAL();
            try
            {
                Tester tester = new Tester();
                tester.ID = DeleteIDTextbox.Text;
                bool close = md.RemoveTester(tester);
            
                if (close)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("The tester does not exist in the system");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);    
            }
            List<Tester> Lst = md.GetTesters();
            foreach (Tester tstr in Lst)
            {
                Console.WriteLine(tstr);
            }
        }
    }
}
