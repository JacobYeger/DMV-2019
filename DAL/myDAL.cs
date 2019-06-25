using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    internal class myDAL : IDAL
    {

        public bool AddTrainee(Trainee trainee)
        {
            foreach (var item in DAL.DataSource.trainees)
            {
                //check if the trainee is already found in the system
                if (item.ID == trainee.ID)
                {
                    throw new Exception("Trainee already exists.");
                }
            }
            //add the trainee and return true as the operation has completed
            DAL.DataSource.trainees.Add(trainee.Clone());
            return true;
        }

        public bool AddTester(Tester tester)
        {
            foreach (Tester item in DAL.DataSource.testers)
            {
                //checks to see if tester is already found in the system
                if (item.ID == tester.ID)
                {
                    throw new Exception("Tester already exists");
                    //   return false;
                }
            }
            //add the tester and return true as the operation has completed
            DAL.DataSource.testers.Add(tester.Clone());
            return true;
        }



        public bool AddDrivingTest(Test drivingTest)
        {
            DAL.DataSource.tests.Add((Test)drivingTest.Clone());
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
            Trainee BadTrainee = (from T in DAL.DataSource.trainees
                                where (T.ID == trainee.ID)
                                select T).FirstOrDefault();
            //return a bool value if the trainees is succesfuly removed       
            return DAL.DataSource.trainees.Remove(BadTrainee);
        }

        public bool RemoveTester(Tester tester)
        {
            //find the bad tester from within the list of testers
            Tester BadTester = (from T in DAL.DataSource.testers
                                where (T.ID == tester.ID)
                                select T).FirstOrDefault();
            //return a bool value if the tester is succesfuly removed       
            return DAL.DataSource.testers.Remove(BadTester);
        }

        public bool RemoveTest(Test test)
        {
            //find the bad test from within the list of tests
            Test BadTest = (from T in DAL.DataSource.tests
                                where (T.TestNumber == test.TestNumber)
                                select T).FirstOrDefault();
            //return a bool value if the test is succesfuly removed
            return DAL.DataSource.tests.Remove(BadTest);
        }

        public bool UpdateDrivingTest(Test drivingTest)
        {
            var x = (from d in DAL.DataSource.tests
                     where (d.TestNumber == drivingTest.TestNumber)
                     select d).FirstOrDefault();

            //x.Tester_ID = drivingTest.Tester_ID;
            //x.StartingPoint = drivingTest.StartingPoint;

            DAL.DataSource.tests.Remove(x);
            DAL.DataSource.tests.Add((Test)drivingTest.Clone());

            return true;
        }
        public bool UpdateTester(Tester tester)
        {
            var x = (from d in DAL.DataSource.testers
                     where (d.ID == tester.ID)
                     select d).FirstOrDefault();
            DAL.DataSource.testers.Remove(x);
            DAL.DataSource.testers.Add((Tester)tester.Clone());

            return true;
        }
        public bool UpdateTrainee(Trainee trainee)
        {
            var x = (from d in DAL.DataSource.trainees
                     where (d.ID ==trainee.ID)
                     select d).FirstOrDefault();
            DAL.DataSource.trainees.Remove(x);
            DAL.DataSource.trainees.Add(trainee.Clone());

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
                result = from t in DAL.DataSource.tests
                         where (p(t))
                         select (Test)t.Clone();
            }
            else
            {
                result = from t in DAL.DataSource.tests
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
                result = from t in DAL.DataSource.trainees
                         where (p(t))
                         select t.Clone();
            }
            else
            {
                result = from t in DAL.DataSource.trainees
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
                result = from t in DAL.DataSource.testers
                         where (p(t))
                         select t.Clone();
            }
            else
            {
                result = from t in DAL.DataSource.testers
                         select t.Clone();
            }
            return result.ToList();
        }
    }
}
