using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace DBL
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
        List<Trainee> GetTrainees(Func<Trainee, bool> p);
        List<Test> GetDrivingTests(Func<Test, bool> p);

    }
}
