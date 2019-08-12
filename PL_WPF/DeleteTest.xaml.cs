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
    /// Interaction logic for DeleteTest.xaml
    /// </summary>
    public partial class DeleteTest : Window
    {
        public DeleteTest()
        {
            InitializeComponent();
        }

        private void PromptAuthorization(object sender, RoutedEventArgs e)
        {
            Dal_imp dal_Imp = new Dal_imp();
            Test test = new Test();
            test.TestNumber = DeleteTestTextbox.Text;
            bool close = dal_Imp.RemoveTest(test);
            if (close)
            {
                this.Close();
            }
            List<Test> Lst = dal_Imp.GetDrivingTests();
            foreach (Test tst in Lst)
            {
                Console.WriteLine(tst);
            }
        }
    }
}
