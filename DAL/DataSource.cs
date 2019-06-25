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
        private static List<Trainee> myTrainees = new List<Trainee>();

        private static List<Tester> Testers;
        private static List<Test> Tests;
        private static List<Trainee> Trainees;

        //Set up some dummy Testers to use for debugging/demonstration
        Tester Tester1 = new BE.Tester {
            FirstName = "Eliezer",
            LastName = "Gensburger",
            Birthday = new DateTime(1970, 1, 1),
            Email = new MailAddress("EG@jct.ac.il"),
            Address = new BE.Address {
                Number = 1,
                Street = "Yafo",
                City = "Jerusalem"
            },
            Gender = BE.Enum.Gender.MALE,
            PhoneNumber = "123456789",
            YearsExperience = 1,
            VehicleSpecialize = VehicleType.PRIVATE_VEHICLE,
            MAX_TESTS_PER_WEEK = 7,
            Max_Distance = 10
        };

        //Set up some dummy Tests to use for debugging/demonstration

        //Set up some dummy Trainees to use for debugging/demonstration

        public static List<Tester> getTesters
        {
            get { return Testers; }
        }

        public static List<Tests> getTests
        {
            get { return Tests; }
        }

        public static List<Trainee> getTrainees
        {
            get { return Trainees; }
        }
    }
}
