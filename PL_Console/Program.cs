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
              
            }
            catch (Exception)
            {

                throw;
            }
          
            

        }
    }
}
