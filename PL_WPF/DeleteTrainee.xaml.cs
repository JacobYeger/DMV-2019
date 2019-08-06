﻿using System;
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
            Dal_imp dal_Imp = new Dal_imp();
            Trainee trainee = new Trainee();
            trainee.ID = DeleteIDTextbox.Text;
            bool close = dal_Imp.RemoveTrainee(trainee);
            if (close)
            {
                this.Close();
            }
            List<Trainee> Lst = dal_Imp.GetTrainees();
            foreach (Trainee trn in Lst)
            {
                Console.WriteLine(trn);
            }
            
        }
    }
}
