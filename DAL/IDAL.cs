using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public interface IDAL
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

        List<Tester> GetTesters(Func<Tester, bool> p = null);
        List<Trainee> GetTrainees(Func<Trainee, bool> p = null);
        List<Test> GetDrivingTests(Func<Test, bool> p = null);

    }
}
