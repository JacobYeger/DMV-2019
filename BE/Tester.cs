using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tester : Person
    {
        public int YearsExperience { get; set; }
        public VehicleType VehicleType { get; set; } //type of vehicle tester specializes in
        public int MAX_TESTS_PER_WEEK { get; set; } //max tests per week
        //public Array WorkDays; //matrix representing days of the week needs to be implemented
        public int Max_Distance { get; set; } //max distance from his house (in Kilometers that he will give a test)

        public override string ToString()
        {
            string result = "";
            //base refers to the class trainee inherits from (person)
            result += base.ToString();
            result += string.Format("Years of experience: {0} \n", YearsExperience);
            result += string.Format("Vehicle specialized: {0} \n", VehicleType);
            result += string.Format("Max tests per week: {0} \n", MAX_TESTS_PER_WEEK);
            //result += string.Format("Work days: {0} \n", WorkDays);
            result += string.Format("Max distance from address {0} \n", Max_Distance);
            return result;
        }
        public Tester Clone()
        {
            return new Tester
            {
                Address = this.Address,
                Birthday = this.Birthday,
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                Gender = this.Gender,
                VehicleType = this.VehicleType,
                YearsExperience = this.YearsExperience,

            };
        }
    }
}
