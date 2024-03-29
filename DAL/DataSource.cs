﻿using BE;
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

        private static List<Tester> Testers = new List<Tester>();
        private static List<Test> Tests = new List<Test>();
        private static List<Trainee> Trainees = new List<Trainee>();

        static DataSource(){
            //Set up some dummy Testers to use for debugging/demonstration
            Tester Tester1 = new BE.Tester
            {
                ID = "886303165",
                FirstName = "Eliezer",
                LastName = "Gensburger",
                Birthday = new DateTime(1970, 1, 1),
                Email = new MailAddress("EG@jct.ac.il"),
                Address = new BE.Address
                {
                    Number = 1,
                    Street = "Yafo",
                    City = "Jerusalem"
                },
                Gender = Gender.MALE,
                PhoneNumber = "123456789",
                YearsExperience = 1,
                VehicleSpecialize = VehicleType.PRIVATE_VEHICLE,
                MAX_TESTS_PER_WEEK = 7,
                Max_Distance = 10
            };

            Testers.Add(Tester1);

            Tester Tester2 = new BE.Tester
            {
                ID = "293082506",
                FirstName = "Moti",
                LastName = "Novick",
                Birthday = new DateTime(1970, 1, 1),
                Email = new MailAddress("MN@jct.ac.il"),
                Address = new BE.Address
                {
                    Number = 2,
                    Street = "Yafo",
                    City = "Jerusalem"
                },
                Gender = Gender.MALE,
                PhoneNumber = "111111111",
                YearsExperience = 2,
                VehicleSpecialize = VehicleType.PRIVATE_VEHICLE,
                MAX_TESTS_PER_WEEK = 4,
                Max_Distance = 10
            };

            Testers.Add(Tester2);

            //Set up some dummy Tests to use for debugging/demonstration

            //Set up some dummy Trainees to use for debugging/demonstration
            Trainee Trainee1 = new Trainee
            {
                Address = new Address
                {
                    City = "JLM",
                    Number = 21,
                    Street = "Havaad Heleumi"
                },
                Birthday = new DateTime(1906, 10, 25),
                Email = new System.Net.Mail.MailAddress("yeger@yeger.com"),
                FirstName = "Yakov",
                LastName = "Yeger",
                ID = "343835955",
                PhoneNumber = "0586623813",
                NumDrivingLessonsPassed = 8,
                Gearbox = Gearbox.AUTOMATIC,
                Gender = Gender.MALE


            };

            Trainee Trainee2 = new Trainee
            {
                Address = new Address
                {
                    City = "JLM",
                    Number = 21,
                    Street = "Havaad Heleumi"
                },
                Birthday = new DateTime(1906, 10, 25),
                Email = new System.Net.Mail.MailAddress("yeger@yeger.com"),
                FirstName = "Jacques",
                LastName = "Benzakein",
                ID = "608376829",
                PhoneNumber = "0586623813",
                Gender = Gender.MALE,

            };

            Trainees.Add(Trainee1);
            Trainees.Add(Trainee2);
        }

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
    }
}
