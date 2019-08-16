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

namespace BL
{
    public class myBL
    {
        IDAL dal = FactoryDAL.getInstance();
        //public List<Trainee> allTrainees()
        //{
        //some verification validation and more ...
        //return dal.getTrainees();
        //}

        //tester interface
        public bool AddTester(Tester tester)
        {
            DateTime today = new DateTime();
            TimeSpan testerAge = today.Subtract(tester.Birthday);
            if (testerAge.Days / 365 < 40)
            {
                return false;
            }

            return true;
        }

        public bool RemoveTester(Tester tester)
        {
            return true;
        }

        public bool UpdateTester(Tester tester)
        {
            DateTime today = new DateTime();
            TimeSpan testerAge = today.Subtract(tester.Birthday);
            if (testerAge.Days / 365 < 40)
            {
                return false;
            }

            return true;
        }

        //trainee interface
        public bool AddTrainee(Trainee trainee)
        {
            DateTime today = new DateTime();
            TimeSpan traineeAge = today.Subtract(trainee.Birthday);
            if (traineeAge.Days / 365 < 18)
            {
                return false;
            }

            return true;
        }

        public bool RemoveTrainee(Trainee trainee)
        {
            return true;
        }

        public bool UpdateTrainee(Trainee trainee)
        {
            DateTime today = new DateTime();
            TimeSpan traineeAge = today.Subtract(trainee.Birthday);
            if (traineeAge.Days / 365 < 18)
            {
                return false;
            }

            return true;
        }

        //Driving test interface
        public bool AddDrivingTest(Test drivingTest)
        {
            Dal_imp dl = new Dal_imp();
            Func<Trainee, bool> anon = (Trainee trn) => (trn.ID == drivingTest.TraineeIdNumber);
            Trainee trainee = dl.GetTrainees(anon).FirstOrDefault();

            Func<Tester,bool> anon2 = (Tester tstr) => (tstr.ID == drivingTest.TesterIdNumber);
            Tester tester = dl.GetTesters(anon2).FirstOrDefault();
            
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
                    return false;
                }
            }

            // It is not possible to add a test to a trainee who has done fewer than 20 lessons
            if (trainee.NumDrivingLessonsPassed < 20)
            {
                return false;
            }

            // It is not possible to add a tester to the test if the tester has exceeded the number of weekly tests he can perform.
            result = from t in dl.GetDrivingTests()
                     where (t.TesterIdNumber == tester.ID && (drivingTest.TestDate.Subtract(t.TestDate).TotalDays < 7))
                     select (Test)t.Clone();

            if (result.ToList().Count < tester.MAX_TESTS_PER_WEEK)
            {
                return false;
            }
            return true;
        }

        public bool RemoveTest(Test drivingTest)
        {
            return true;
        }

        public bool UpdateDrivingTest(Test drivingTest)
        {
            return true;
        }


        //Location
        public List<Tester> getTestersWithinDistance(Address addr, int kilometers)
        {
            Dal_imp di = new Dal_imp();
            /*
             * bool anonymousFunc(tester){
             *      if(tester.addr-addr < 40){
             *          return true;
             *      }
             * }
             */
            Func<Tester, bool> anon = (Tester tstr) => (distance(tstr.Address, addr) < kilometers);
            return di.GetTesters();
        }

        public double distance(Address from, Address to)
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
    }
}