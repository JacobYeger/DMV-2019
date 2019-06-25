using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    static class DataSource
    {
        private static List<Trainee> myTrainees = new List<Trainee>();

        public static List<Trainee> getTrainees
        {
            get { return myTrainees; }
        }

        public static List<Tester> testers;
        public static List<Test> tests;
        public static List<Trainee> trainees;
    }
}
