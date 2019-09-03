using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace DAL
{
    public class myDAL_XML : IDAL
    {
        string TestsFilePath = "Tests.xml";
        string TestersFilePath = "Testers.xml";
        string TraineesFilePath = "Trainees.xml";
        string ConfigFilePath = "Config.xml";
        XElement TestsRoot;
        XElement ConfigRoot;


        public myDAL_XML()
        {
            //linq-to-xml
            if (File.Exists(TestsFilePath))
            {
                //Then just load the file into memory
                TestsRoot = XElement.Load(TestsFilePath);
            }
            else
            {
                //Otherwise create the file
                TestsRoot = new XElement("TestsFile");
                TestsRoot.Save(TestsFilePath);
            }

            if (File.Exists(ConfigFilePath))
            {
                //Then just load the file into memory
                XElement CurrentTestNumber = new XElement("CurrentTestNumber", 0);
                ConfigRoot = new XElement("Config", CurrentTestNumber);

                ConfigRoot.Save(ConfigFilePath);
            }
            else
            {
                //Otherwise create the file
                ConfigRoot = new XElement("ConfigFile");
            }

            //Serialize
            if (File.Exists(TraineesFilePath))
            {
                //Just load the file
                DAL.DataSource.Trainees = LoadListFromXML<Trainee>(TraineesFilePath);
            }
            else
            {
                //otherwise create the file
                FileStream TraineeFileStream = new FileStream(TraineesFilePath, FileMode.Create);
                TraineeFileStream.Close();
                DAL.DataSource.Trainees = new List<Trainee>();
                SaveListToXML<Trainee>(new List<Trainee>(), TraineesFilePath);
            }

            if (File.Exists(TestersFilePath))
            {
                //Just load the file
                DAL.DataSource.Testers = LoadListFromXML<Tester>(TestersFilePath);
            }
            else
            {
                //otherwise create the file
                FileStream TestersFileStream = new FileStream(TestersFilePath, FileMode.Create);
                TestersFileStream.Close();
                DAL.DataSource.Testers = new List<Tester>();
                SaveListToXML<Tester>(new List<Tester>(), TestersFilePath);
            }
        }

        public bool AddTrainee(Trainee Trainee)
        {
            //Check XMl for trainee Id number. If it exists, return false or throw an error
            //If not, add trainee to the XML
            return true;
        }

        public bool AddTester(Tester Tester)
        {
            //Checl XMl for tester Id number. If it exists, return false or throw an error
            //If not, add tester to the XML
            return true;
        }

        public bool AddDrivingTest(Test drivingTest)
        {
            //Check if test has Test number of 0. If so, assign new test number to it, and update the config XML
            //if not, leave test number alone
            //Check XML for test number. If it exists, return false or throw an error
            //if not, add to XML file
            return true;

        }

        public bool RemoveTrainee(Trainee trainee)
        {
            //Locate trainee in XML. If he doesn't exist, return false or throw error
            //If he does, remove him 
            
            return DAL.DataSource.getTrainees.Remove(BadTrainee);
        }

        public bool RemoveTester(Tester Tester)
        {
            //Locate tester in XML. If he doesn't exist, return false or throw error
            //If he does, remove him
            
            return DAL.DataSource.getTesters.Remove(BadTester);
        }

        public bool RemoveTest(Test test)
        {
            //Locate test in XML. If it doesn't exist, return false or throw error
            //If it does, remove it
            return DAL.DataSource.getTests.Remove(BadTest);
        }

        public bool UpdateDrivingTest(Test drivingTest)
        {
            //Locate test in XML. If it doesn't exist, return false or throw error
            //If it does, remove it and replace it

            return true;
        }
        public bool UpdateTester(Tester tester)
        {
            //Locate tester in XML. If he doesn't exist, return false or throw error
            //If he does, remove him and replace him

            return true;
        }
        public bool UpdateTrainee(Trainee trainee)
        {
            //Locate trainee in XML. If he doesn't exist, return false or throw error
            //If he does, remove him and replace him

            return true;
        }


        //returns the list of driving tests
        public List<Test> GetDrivingTests(Func<Test, bool> p = null)
        {
            IEnumerable<Test> result = null;

            return result.ToList();
        }

        //getter for trainees with functionality for adding conditions on the search
        public List<Trainee> GetTrainees(Func<Trainee, bool> p = null)
        {
            IEnumerable<Trainee> result = null;

            return result.ToList();
        }

        //getter for Testers with functionality for adding conditions on the search 
        public List<Tester> GetTesters(Func<Tester, bool> p = null)
        {
            IEnumerable<Tester> result = null;

            return result.ToList();
        }


        public XElement AddressToXElement(Address addr)
        {
            XElement Address = new XElement("Address");

            XElement City = new XElement("City", addr.City);
            Address.Add(City);

            XElement Street = new XElement("Street", addr.Street);
            Address.Add(Street);

            XElement Number = new XElement("Number", addr.Number);
            Address.Add(Number);

            return Address;
        }

        public List<T> LoadListFromXML<T>(Path path)
        {
            List<T> list = new List<T>();

            //Pull list out of XML file

            return list;

        }

        public void SaveListToXML<T>(List<T> list, Path path)
        {

        }
        
    }

}