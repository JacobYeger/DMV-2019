using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{

    public class Dal_imp : IDAL
    {

        public bool AddTrainee(Trainee trainee)
        {
            foreach (var item in DAL.DataSource.getTrainees)
            {
                //check if the trainee is already found in the system
                if (item.ID == trainee.ID)
                {
                    throw new Exception("Trainee already exists.");
                }
            }
            //add the trainee and return true as the operation has completed
            DAL.DataSource.getTrainees.Add(trainee.Clone());
            return true;
        }

        public bool AddTester(Tester Tester)
        {
            foreach (Tester item in DAL.DataSource.getTesters)
            {
                //checks to see if Tester is already found in the system
                if (item.ID == Tester.ID)
                {
                    throw new Exception("Tester already exists");
                    //   return false;
                }
            }
            //add the Tester and return true as the operation has completed
            DAL.DataSource.getTesters.Add(Tester.Clone());
            return true;
        }

        public bool AddDrivingTest(Test drivingTest)
        {
            Test TestToAdd = (Test)drivingTest.Clone();
            TestToAdd.TestNumber = (++Configuration.CurrentTestNumber).ToString();
            DAL.DataSource.getTests.Add(TestToAdd);
            return true;
        }
        /*
        public bool RemoveTrainee(Trainee trainee)
        {
            foreach (var item in DataSource.Trainees)
            {
                if (item.ID == trainee.ID)
                    return DataSource.Trainees.Remove(item);
            }
            return false;
        }
        */
        public bool RemoveTrainee(Trainee trainee)
        {
            //find the bad trainee from within the list of trainees
            Trainee BadTrainee = (from T in DAL.DataSource.getTrainees
                                  where (T.ID == trainee.ID)
                                  select T).FirstOrDefault();
            //return a bool value if the trainees is succesfuly removed       
            return DAL.DataSource.getTrainees.Remove(BadTrainee);
        }

        public bool RemoveTester(Tester Tester)
        {
            //find the bad Tester from within the list of Testers
            Tester BadTester = (from T in DAL.DataSource.getTesters
                                where (T.ID == Tester.ID)
                                select T).FirstOrDefault();
            //return a bool value if the Tester is succesfuly removed       
            return DAL.DataSource.getTesters.Remove(BadTester);
        }

        public bool RemoveTest(Test test)
        {
            //find the bad test from within the list of tests
            Test BadTest = (from T in DAL.DataSource.getTests
                            where (T.TestNumber == test.TestNumber)
                            select T).FirstOrDefault();
            //return a bool value if the test is succesfuly removed
            return DAL.DataSource.getTests.Remove(BadTest);
        }

        public bool UpdateDrivingTest(Test drivingTest)
        {
            var x = (from d in DAL.DataSource.getTests
                     where (d.TestNumber == drivingTest.TestNumber)
                     select d).FirstOrDefault();
            //x.Tester_ID = drivingTest.Tester_ID;
            //x.StartingPoint = drivingTest.StartingPoint;

            DAL.DataSource.getTests.Remove(x);
            DAL.DataSource.getTests.Add((Test)drivingTest.Clone());

            return true;
        }
        public bool UpdateTester(Tester tester)
        {
            var x = (from d in DAL.DataSource.getTesters
                     where (d.ID == tester.ID)
                     select d).FirstOrDefault();
            DAL.DataSource.getTesters.Remove(x);
            DAL.DataSource.getTesters.Add((Tester)tester.Clone());

            return true;
        }
        public bool UpdateTrainee(Trainee trainee)
        {
            var x = (from d in DAL.DataSource.getTrainees
                     where (d.ID == trainee.ID)
                     select d).FirstOrDefault();
            DAL.DataSource.getTrainees.Remove(x);
            DAL.DataSource.getTrainees.Add(trainee.Clone());

            return true;
        }

        /*  public List<Trainee> GetAllTrainees()
          {
              List<Trainee> result = new List<Trainee>();
              foreach (var item in DataSource.trainees)
              {
                  result.Add(item.Clone());
              }
              return result;
          }
          */
        //returns the list of driving tests
        public List<Test> GetDrivingTests(Func<Test, bool> p = null)
        {
            IEnumerable<Test> result = null;
            //if no condition was put on search, return all
            if (p != null)
            {
                result = from t in DAL.DataSource.getTests
                         where (p(t))
                         select (Test)t.Clone();
            }
            else
            {
                result = from t in DAL.DataSource.getTests
                         select (Test)t.Clone();
            }
            return result.ToList();
        }

        //getter for trainees with functionality for adding conditions on the search
        public List<Trainee> GetTrainees(Func<Trainee, bool> p = null)
        {
            IEnumerable<Trainee> result = null;
            //if no condition was put on search, return all
            if (p != null)
            {
                result = from t in DAL.DataSource.getTrainees
                         where (p(t))
                         select t.Clone();
            }
            else
            {
                result = from t in DAL.DataSource.getTrainees
                         select t.Clone();
            }
            return result.ToList();
        }

        //getter for Testers with functionality for adding conditions on the search 
        public List<Tester> GetTesters(Func<Tester, bool> p = null)
        {
            IEnumerable<Tester> result = null;
            //if no condition was put on search, return all
            if (p != null)
            {
                result = from t in DAL.DataSource.getTesters
                         where (p(t))
                         select t.Clone();
            }
            else
            {
                result = from t in DAL.DataSource.getTesters
                         select t.Clone();
            }
            return result.ToList();
        }
    }
}