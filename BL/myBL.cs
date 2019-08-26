using BE;
using DAL;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net;
using System.Xml;
using System.ComponentModel;
using System.Threading;

namespace BL
{
    public class myBL: IBL
    {
        IDAL dal = FactoryDAL.getInstance();
        //public List<Trainee> allTrainees()
        //{
        //some verification validation and more ...
        //return dal.getTrainees();
        //}
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        List<Tester> ListOfTestersInProximity;

        //tester interface
        public bool AddTester(Tester tester)
        {
            DateTime today = DateTime.Now;
            TimeSpan testerAge = today.Subtract(tester.Birthday);
            /*
            Console.WriteLine("Today: " + today);
            Console.WriteLine("Tester birthday: " + tester.Birthday);
            Console.WriteLine("Tester age: " + testerAge.Days);
            */
            if (testerAge.Days / 365 < 40)
            {
                throw new Exception("Impossible to add a tester under the age of 40");
                return false;
            }

            
            return dal.AddTester(tester);
        }

        public bool RemoveTester(Tester tester)
        {
            myDAL md = new myDAL();
            return md.RemoveTester(tester);
            
        }

        public bool UpdateTester(Tester tester)
        {
            DateTime today = DateTime.Now;
            TimeSpan testerAge = today.Subtract(tester.Birthday);
            if (testerAge.Days / 365 < 40)
            {
                throw new Exception("Impossible to add a tester under the age of 40");
                return false;
            }

            return dal.UpdateTester(tester);
        }

        //trainee interface
        public bool AddTrainee(Trainee trainee)
        {
            myDAL md = new myDAL();

            DateTime today = DateTime.Now;
            TimeSpan traineeAge = today.Subtract(trainee.Birthday);
            if (traineeAge.Days / 365 < 18)
            {
                throw new Exception("Impossible to add trainee below 18 years of age");
                return false;
            }

            return md.AddTrainee(trainee);
        }

        public bool RemoveTrainee(Trainee trainee)
        {
            myDAL md = new myDAL();
            return md.RemoveTrainee(trainee);
        }

        public bool UpdateTrainee(Trainee trainee)
        {
            myDAL md = new myDAL();

            DateTime today = DateTime.Now;
            TimeSpan traineeAge = today.Subtract(trainee.Birthday);
            if (traineeAge.Days / 365 < 18)
            {
                throw new Exception("Impossible to add trainee below 18 years of age");
                return false;
            }

            return md.UpdateTrainee(trainee);
        }

        //Driving test interface
        public bool AddDrivingTest(Test drivingTest)
        {
            myDAL dl = new myDAL();
            Func<Trainee, bool> anon = (Trainee trn) => (trn.ID == drivingTest.TraineeIdNumber);
            Trainee trainee;
            IEnumerable<Trainee> traineeList = dl.GetTrainees(anon);
            if(traineeList.Count() > 0)
            {
                 trainee = traineeList.FirstOrDefault();
            }
            else
            {
                throw new Exception("No trainee exists in our database with that ID number.");
            }
            
            //Can't schedule a test for the past, silly
            if (drivingTest.TestDate.Subtract(DateTime.Now).TotalMilliseconds < 0)
            {
                throw new Exception("Can't schedule test in the past.");
            }
            
            
            //It is not possible to add a test before 7 days have passed from the trainee’s previous test (if any).
            IEnumerable<Test> result = from t in dl.GetDrivingTests()
                                       where t.TraineeIdNumber == trainee.ID
                                       orderby t.TestDate descending
                                       select (Test)t.Clone();
            if (result.ToList().Count != 0)
            {
                Test testToCompare = result.ToList().FirstOrDefault();
                if ((drivingTest.TestDate.Subtract(testToCompare.TestDate)).Days < 7)
                {
                    throw new Exception("It is not possible to add a test before 7 days have passed from the trainee’s previous test (if any).");
                    return false;
                }
            }
            
            // It is not possible to add a test to a trainee who has done fewer than 20 lessons
            if (trainee.NumDrivingLessonsPassed < 20)
            {
                return false;
            }
            
            //Two tests at the same time cannot be set up for the tester/ trainee
            result = from t in dl.GetDrivingTests()
                     where (t.TraineeIdNumber == trainee.ID && t.TestDate == drivingTest.TestDate && t.TestTime == drivingTest.TestTime)
                     select (Test)t.Clone();
            //If there are any tests with this trainee at this time
            if (result.ToList<Test>().Count != 0)
            {
                return false;
            }

            //• It is not possible to set up a test on a type of vehicle for a student who has already passed a driving test on that type of vehicle.
            result = from t in dl.GetDrivingTests()
                     //Todo: Add VehicleType property to test, uncomment line below
                     //where (t.TraineeIdNumber == trainee.ID && t.VehicleType = drivingTest.VehicleType && t.TestResult == 1)
                     select (Test)t.Clone();
            //If there are any tests with this trainee and this vehicle type where he passed
            if (result.ToList<Test>().Count != 0)
            {
                return false;
            }

            Func<Tester, bool> anon2 = (Tester tstr) => (isValidTester(tstr, trainee, drivingTest));
            List<Tester> testerList = dl.GetTesters(anon2);
            if(testerList.Count == 0)
            {
                throw new Exception("There were no testers that matched your criteria");
                return false;
            }

            Tester tester = testerList.First();
            drivingTest.TesterIdNumber = tester.ID;
            //If he has not violated any of the above rules
            return true;
        }

        private bool isValidTester(Tester tester, Trainee trainee, Test test)
        {
            myDAL dl = new myDAL();

            // It is not possible to add a tester to the test if the tester has exceeded the number of weekly tests he can perform.
            IEnumerable<Test> result = from t in dl.GetDrivingTests()
                     where (t.TesterIdNumber == tester.ID && (test.TestDate.Subtract(t.TestDate).TotalDays < 7))
                     select (Test)t.Clone();

            if (result.ToList().Count < tester.MAX_TESTS_PER_WEEK)
            {
                return false;
            }

            //Two tests at the same time cannot be set up for the tester/ trainee
            result = from t in dl.GetDrivingTests()
                     where (t.TesterIdNumber == tester.ID && t.TestDate == test.TestDate && t.TestTime == test.TestTime)
                     select (Test)t.Clone();
            //If there are any tests with this tester at this time
            if (result.ToList<Test>().Count != 0)
            {
                return false;
            }

            // In setting up a test, the type of vehicle on which the trainee studied and the tester’s specialty must match
            if (trainee.VehicleType != tester.VehicleSpecialize)
            {
                return false;
            }

            //If he has not violated any of the above rules
            return true;


        }

        public bool RemoveTest(Test drivingTest)
        {
            myDAL md = new myDAL();
            //return trueif the test id was in there, false otherwise
            return md.RemoveTest(drivingTest);
        }

        public bool UpdateDrivingTest(Test drivingTest)
        {
            //allows for the tester to score the test 
            Test test = new Test();

            
            test.TestNumber = drivingTest.TestNumber;
            test.MaintainingDistance = drivingTest.MaintainingDistance;
            test.MirrorChecking = drivingTest.MirrorChecking;
            test.ParkingInReverse = drivingTest.ParkingInReverse;
            test.Signaling = drivingTest.Signaling;

            test.TestTime = drivingTest.TestTime;

            test.TestStartPoint = drivingTest.TestStartPoint;

            test.TestScore = drivingTest.TestScore;

            test.TestersComments = drivingTest.TestersComments;

            myDAL md = new myDAL();
            //return trueif the test id was in there, false otherwise
            //md.RemoveTest(drivingTest);
            return md.UpdateDrivingTest(test);
        }   


        //Location
        public List<Tester>  getTestersWithinDistance(Address addr, int kilometers)
        {
            myDAL md = new myDAL();
            /*
             * bool anonymousFunc(tester){
             *      if(tester.addr-addr < 40){
             *          return true;
             *      }
             * }
             */
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            
            Func<Tester, bool> anon = (Tester tstr) => (Distance(tstr.Address, addr) < kilometers);
            backgroundWorker1.RunWorkerAsync(anon);
            //List<Tester> ListOfTestersInProximity = md.GetTesters(anon);
            return ListOfTestersInProximity;
           // for(i,j):
             //   schedule[i,j] = (CheckBox)"Checkbox{i}{j}".ischecked
        }

        public double Distance(Address from, Address to)
        {
            string origin = from.Number + " " + from.Street + " " + from.City;
            string destination = to.Number + " " + to.Street + " " + to.City;
            string KEY = "pcNsEXrtoCyYnfAQFBGTTHCx1cUDnMT3";

            string url = @"https://www.mapquestapi.com/directions/v2/route" +
            @"?key=" + KEY +
            @"&from=" + origin +
            @"&to=" + destination +
            @"&outFormat=xml" +
            @"&ambiguities=ignore&routeType=fastest&doReverseGeocode=false" +
            @"&unit=m" +
            @"&enhancedNarrative=false&avoidTimedConditions=false";
            //request from MapQuest service the distance between the 2 addresses
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader sreader = new StreamReader(dataStream);
            string responsereader = sreader.ReadToEnd();
            response.Close();
            //the response is given in an XML format
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.LoadXml(responsereader);
            if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "0")
            //we have the expected answer
            {
                //display the returned distance
                XmlNodeList distance = xmldoc.GetElementsByTagName("distance");
                double distInMiles = Convert.ToDouble(distance[0].ChildNodes[0].InnerText);
                double distInKM = Convert.ToDouble(distance[0].ChildNodes[0].InnerText)*1.609344;

                //Console.WriteLine("Distance In KM: " + distInMiles * 1.609344);

                //int result = (int)(distInMiles * 1.609344);

                //e.Result result;
                return distInKM;
                //display the returned driving time
                // XmlNodeList formattedTime = xmldoc.GetElementsByTagName("formattedTime");
                // string fTime = formattedTime[0].ChildNodes[0].InnerText;
                //  Console.WriteLine("Driving Time: " + fTime);
            }
            else if (xmldoc.GetElementsByTagName("statusCode")[0].ChildNodes[0].InnerText == "402")
            //we have an answer that an error occurred, one of the addresses is not found
            {
                Console.WriteLine("An error occurred, one of the addresses is not found. Try again.");
               
            }
            else //busy network or other error...
            {
                Console.WriteLine("We haven't got an answer, maybe the net is busy...");
               
            }
            return int.MaxValue;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            myDAL md = new myDAL();
            Func<Tester, bool> anon = (Func<Tester, bool>)e.Argument;
            e.Result = md.GetTesters(anon);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // First, handle the case where an exception was thrown.
            if (e.Error != null)
            {
                throw new Exception(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled 
                // the operation.
                // Note that due to a race condition in 
                // the DoWork event handler, the Cancelled
                // flag may not have been set, even though
                // CancelAsync was called.
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.
                ListOfTestersInProximity = (List<Tester>)e.Result;
            }
        }

        public List<Tester> GetTesters(Func<Tester, bool> p = null)
        {
            myDAL md = new myDAL();
            return md.GetTesters(p);
        }

        public List<Trainee> GetTrainees(Func<Trainee, bool> p = null)
        {
            myDAL md = new myDAL();
            return md.GetTrainees(p);
        }

        public List<Test> GetDrivingTests(Func<Test, bool> p = null)
        {
            myDAL md = new myDAL();
            return md.GetDrivingTests(p);
        }

        public List<Tester> GetTestersAvailableAtTime(DateTime time)
        {
            int DayOfWeek = (int)time.DayOfWeek;

            //No one works on friday or shabbat
            if(DayOfWeek == 5 || DayOfWeek == 6)
            {
                return new List<Tester>();
            }
            
            int Hour = time.Hour -8;
            //No one works before 8 am or after 4 pm
            if(Hour < 0 || Hour > 7)
            {
                return new List<Tester>();
            }
            
            myDAL md = new myDAL();
            List<Tester> result = from T in md.GetTesters
                                where (T.AvailabilityMatrix[DayOfWeek,Hour])
                                select T;
        }

        public int TestsTakenByTrainee(Trainee trainee)
        {
            myDAL dl = new myDAL();
            IEnumerable<Test> result = from t in dl.GetDrivingTests()
                                       where (t.TraineeIdNumber == trainee.ID)
                                       select (Test)t.Clone();
            return result.ToList().Count;
        }

        public bool IsEntitledToLicense(Trainee trainee)
        {
            myDAL dl = new myDAL();
            IEnumerable<Test> result = from t in dl.GetDrivingTests()
                                         where (t.TraineeIdNumber == trainee.ID && t.TestResult == 1)
                                         select (Test)t.Clone();
            if (result.ToList().Count != 0)
            {
                return true;
            }

            return false;
        }

        //A function that returns a list of all scheduled tests by day
        public List<Test> AllTestsInDay(DateTime day)
        {
            throw new NotImplementedException();
        }

        //A function that returns a list of all scheduled tests by month
        public List<Test> AllTestsInMonth(DateTime month)
        {
            throw new NotImplementedException();
        }
        
        //Grouping
        //A group of testers according to type of specialization
        public List<Tester> GetTestersGroupedBySpecialty(bool sort = false)
        {
            myDAL dl = new myDAL();
            IEnumerable<Tester> result;
            if(sort)
            {
                result = from t in dl.GetTesters()
                         orderby t.LastName
                         group t by t.VehicleSpecialize into newGroup
                         select (Tester)newGroup;
            }
            else
            {
                result = from t in dl.GetTesters()
                         group t by t.VehicleSpecialize into newGroup
                         select (Tester)newGroup;
            }
            return (List<Tester>) result;

        }

        //A list of trainees grouped according to the driving school in which they studied
        public List<Trainee> GetTraineesGroupedBySchool(bool sort = false)
        {
            myDAL dl = new myDAL();
            IEnumerable<Trainee> result;
            if(sort)
            {
                result = from t in dl.GetTrainees()
                         orderby t.LastName
                         group t by t.DrivingSchool into newGroup
                         select (Trainee)newGroup;
            }
            else
            {
                result = from t in dl.GetTrainees()
                         group t by t.DrivingSchool into newGroup
                         select (Trainee)newGroup;
            }
            return (List<Trainee>) result;
        }

        //A list of trainees grouped according to the driving instructor with whom they studied
        public List<Trainee> GetTraineesGroupedByInstructor(bool sort = false)
        {
            myDAL dl = new myDAL();
            IEnumerable<Trainee> result;
            if(sort)
            {
                result = from t in dl.GetTrainees()
                         orderby t.LastName
                         group t by t.DrivingInstructor into newGroup
                         select (Trainee)newGroup;
            }
            else
            {
                result = from t in dl.GetTrainees()
                         group t by t.DrivingInstructor into newGroup
                         select (Trainee)newGroup;
            }
            return (List<Trainee>) result;
        }
        
        //A list of trainees grouped according to the number of tests they took
        public List<Trainee> GetTraineesGroupedByNumberOfTests(bool sort = false)
        {
            myDAL dl = new myDAL();
            IEnumerable<Trainee> result;
            if(sort)
            {
                result = from t in dl.GetTrainees()
                         orderby t.LastName
                         group t by TestsTakenByTrainee(t) into newGroup
                         select (Trainee)newGroup;
            }
            else
            {
                result = from t in dl.GetTrainees()
                         group t by TestsTakenByTrainee(t) into newGroup
                         select (Trainee)newGroup;
            }
            return (List<Trainee>) result;
        }
    }
}