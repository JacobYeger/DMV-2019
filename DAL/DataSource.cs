using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace DAL
{
    static class DataSource
    {
        //private static List<Trainee> myTrainees = new List<Trainee>();

        private static List<Tester> Testers = new List<Tester>();
        private static List<Test> Tests = new List<Test>();
        private static List<Trainee> Trainees = new List<Trainee>();
 
        public static List<Tester> getTesters
        {
            get { return Testers; }
        }

        public static List<Test> getTests
        {
            get { return Tests; }
        }

        public static List<Trainee> getTrainees
        {
            get { return Trainees; }
        }



        static DataSource(){
            
        }
    }
}
