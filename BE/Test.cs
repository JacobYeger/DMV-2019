using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    class Test
    {
        public string TestNumber { get; set; } //test number
        public string TesterIdNumber { get; set; }//ID number of the tester
        public string TraineeIdNumber { get; set; } //ID number of the trainee
        public DateTime TestDate { get; set; }//date of the test
        public DateTime TestTime { get; set; } //Time of the test
        public Address TestStartPoint { get; set; }//address denoting starting point of the test
        public bool MirrorChecking { get; set; } //did trainee check   mirrors properly?
        public bool ParkingInReverse { get; set; } //did trainee park in reverse properly?
        public bool MaintainingDistance { get; set; }//did trainee maintain proper distance?
        public bool Signaling { get; set; } //did trainee signal appropriately
        public int TestScore;//holds the value of the test score
        //test result will print the result of the examination
        public int TestResult
        {
            get
            {
                if (TestScore < 60) //if trainee receives grade below 60
                {
                    Console.WriteLine(Configuration.FAILED);//prints failure message
                    return 0;
                }
                else
                    Console.WriteLine(Configuration.PASSED);//prints success message
                    return 0; 
            }
            set { TestScore = value; } //sets value of the test score
        }





    }
}
