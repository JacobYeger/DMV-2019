using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Trainee : Person
    {
        public VehicleType VehicleType { get; set; }//type of vehicle trainee studied on
        public Gearbox Gearbox { get; set; }//type of gearbox trainee studied on
        public DrivingSchool DrivingSchool { get; set; } //location of the driving school studied at
        public string DrivingInstructor { get; set; } //Driving instructor for the trainee
        public int NumDrivingLessonsPassed { get; set; }//number of driving lessons passed by trainee

        //allows for the printing of the trainee details
        public override string ToString()
        {
            string result = "";
            //base refers to the class trainee inherits from (person)
            result += base.ToString();
            result += string.Format("VehicleType: {0} \n", VehicleType);
            result += string.Format("drivingSchool: {0} \n", DrivingSchool);
            result += string.Format("Gearbox studied: {0} \n", Gearbox);
            result += string.Format("DrivingInstructor: {0} \n", DrivingInstructor);
            result += string.Format("NumDrivingLessonsPassed: {0} \n", NumDrivingLessonsPassed);
            return result;
        }

        public Trainee Clone()
        {
            return new Trainee
            {
                //copies all values to new clone
                Address = this.Address,
                Birthday = this.Birthday,
                Email = this.Email,
                FirstName = this.FirstName,
                Gender = this.Gender,
                LastName = this.LastName,
                VehicleType = this.VehicleType,
                Gearbox = this.Gearbox,
                PhoneNumber = this.PhoneNumber,
                DrivingSchool = this.DrivingSchool


            };
        }

    }
}
