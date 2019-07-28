using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DAL;
using System.Net.Mail;

namespace PL_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            DAL.Dal_imp D = new DAL.Dal_imp();

            List<Test> lst;
            /*foreach(Tester tstr in lst)
            {
                Console.WriteLine(tstr);
            }*/

            Tester Tester3 = new BE.Tester
            {
                ID = "628070922",
                FirstName = "Tester",
                LastName = "Three",
                Birthday = new DateTime(1970, 1, 1),
                Email = new MailAddress("TT@jct.ac.il"),
                Address = new BE.Address
                {
                    Number = 3,
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

            D.AddTester(Tester3);

            //Console.WriteLine("----------------------------------------------------");

            //lst = D.GetTesters();
            /*foreach(Tester tstr in lst)
            {
                Console.WriteLine(tstr);
            }*/

            Test Test1 = new Test{
                TesterIdNumber = "628070922",
                TraineeIdNumber = "343835955",
                TestDate = new DateTime().Date,
                TestTime = new DateTime().Date,
                TestStartPoint = new Address
                {
                    City = "JLM",
                    Number = 22,
                    Street = "Havaad Heleumi"
                },
                MirrorChecking  = true,
                ParkingInReverse = true,
                MaintainingDistance = true,
                Signaling = true
            };

            D.AddDrivingTest(Test1);

            Test Test2 = new Test{
                TesterIdNumber = "628070922",
                TraineeIdNumber = "343835955",
                TestDate = new DateTime().Date,
                TestTime = new DateTime().Date,
                TestStartPoint = new Address
                {
                    City = "JLM",
                    Number = 23,
                    Street = "Havaad Heleumi"
                },
                MirrorChecking  = true,
                ParkingInReverse = true,
                MaintainingDistance = true,
                Signaling = true
            };

            D.AddDrivingTest(Test2);

            Test Test3 = new Test{
                TesterIdNumber = "628070922",
                TraineeIdNumber = "343835955",
                TestDate = new DateTime().Date,
                TestTime = new DateTime().Date,
                TestStartPoint = new Address
                {
                    City = "JLM",
                    Number = 24,
                    Street = "Havaad Heleumi"
                },
                MirrorChecking  = true,
                ParkingInReverse = true,
                MaintainingDistance = true,
                Signaling = true
            };

            D.AddDrivingTest(Test3);

            lst = D.GetDrivingTests();

            foreach(Test tst in lst)
            {
                Console.WriteLine(tst);
            }
            
            Console.WriteLine("Foo");
            Console.ReadKey();
        }
    }
}
