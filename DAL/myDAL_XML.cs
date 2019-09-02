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
    class myDAL_XML : IDAL
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
                saveListToXML<Trainee>(new List<Trainee>(), TraineesFilePath);
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
                saveListToXML<Tester>(new List<Tester>(), TestersFilePath);
            }
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
    }

}