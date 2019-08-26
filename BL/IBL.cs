using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public interface IBL
    {
        //tester interface
        bool AddTester(Tester tester);
        bool RemoveTester(Tester tester);
        bool UpdateTester(Tester tester);

        //trainee interface
        bool AddTrainee(Trainee trainee);
        bool RemoveTrainee(Trainee trainee);
        bool UpdateTrainee(Trainee trainee);

        //Driving test interface
        bool AddDrivingTest(Test drivingTest);
        bool RemoveTest(Test drivingTest);
        bool UpdateDrivingTest(Test drivingTest);

        List<Tester> GetTesters(Func<Tester, bool> p);
        List<Trainee> GetTrainees(Func<Trainee, bool> p );

        //A function that can return all tests that meet a specific condition (i.e. the function accepts a delegate that matches the 
        //functions that receive a test and returns bool, and thus the condition is defined)
        List<Test> GetDrivingTests(Func<Test, bool> p = null);

        //A function that receives a date and time and returns all testers who are available
        //at that time.The function will check whether the date and time are the tester's
        //working hours and whether the tester is giving another test at that time
        List<Tester> GetTestersAvailableAtTime(DateTime time);

        //A function that a receives a trainee number, and returns the number of tests he took
        int TestsTakenByTrainee(Trainee trainee);

        //A function that a receives a trainee number and returns if he is entitled to a driving license (if he has passed a driving test).
        bool IsEntitledToLicense(Trainee trainee);

        //A function that returns a list of all scheduled tests by day
        List<Test> AllTestsInDay(DateTime day);

        //A function that returns a list of all scheduled tests by month
        List<Test> AllTestsInMonth(DateTime month);

        // A group of testers according to type of specialization
        List<Tester> GetTestersGroupedBySpecialty(bool sort = false);

        //A list of trainees grouped according to the driving school in which they studied
        List<Trainee> TraineesGroupedBySchool();

        //A list of trainees grouped according to the driving instructor with whom they studied
        List<Trainee> TraineesGroupedByInstructor();
        
        //A list of trainees grouped according to the number of tests they took
        List<Trainee> TraineesGroupedByNumberOfTests();



    }
}
