using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PL_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {


                BE.Test test1 = new BE.Test { TestNumber = "TestNumber", TesterIdNumber = "TesterIdNumber", TraineeIdNumber = "TraineeIdNumber", TestDate = DateTime.Now, TestTime = DateTime.Now, TestStartPoint = new Address(), MirrorChecking = true, ParkingInReverse = true, MaintainingDistance = true, Signaling = true, TestScore = 100 };
                BE.Test test2 = (Test)test1.Clone();

                test2.TestNumber = "test";

                Console.WriteLine(test1);
                Console.WriteLine(test2);


                Trainee trainee = new Trainee
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
                Tester tester = new Tester
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
                    ID = "111111118",
                    PhoneNumber = "0586623813",
                    Gender = Gender.MALE,                    
                    YearsExperience = 8,
                    VehicleSpecialize = VehicleType.HEAVY_TRUCK
                };
                Console.WriteLine("TRAINEE: \n");
                Console.WriteLine(trainee);
                Console.WriteLine("Tester: \n");
                Console.WriteLine(tester);
                Console.WriteLine("\n");
                Console.WriteLine("Press any key to continue:\n");
                Console.ReadKey();

              
            }
            catch (Exception)
            {

                throw;
            }
          
            

        }
    }
}
