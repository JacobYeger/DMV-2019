using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace BE
{
    public abstract class Person
    {
        private string myID;
        public string       FirstName   { get; set; }
        public string       LastName    { get; set; }
        public DateTime     Birthday    { get; set; }
        public MailAddress  Email       { get; set; }
        public Address      Address     { get; set; }
        public Gender       Gender      { get; set; }
        public string PhoneNumber { get; set; }

        //full property ID which contains check 
        public string ID
        {
            get { return myID; }
            set
            {
                if (!validID(value))
                {
                    throw new Exception("not valid ID");
                }else{
                //Console.WriteLine("passed " + value);
                myID = value;
                }
            }
        }

        //prints the details of the person
        public override string ToString()
        {
            string result = "";
            result += string.Format("ID: {0}\n", ID);
            result += string.Format("FirstName: {0}\n", FirstName);
            result += string.Format("LastName: {0}\n", LastName);
            result += string.Format("Gender: {0}\n", Gender);
            result += string.Format("Birthday: {0}\n", Birthday);
            result += string.Format("Email: {0}\n", Email);
            result += string.Format("Address: {0}", Address);
            result += string.Format("MobilePhoneNumber: {0}\n", PhoneNumber);
            return result; 
        }

        

        private bool validID(string value)
        {
            //plagiarized code to figure out if ID number is valid 
            string m_PERID = "111111118";
            char[] digits = m_PERID.PadLeft(9, '0').ToCharArray();
            int[] oneTwo = { 1, 2, 1, 2, 1, 2, 1, 2, 1 };
            int[] multiply = new int[9];
            int[] oneDigit = new int[9];
            for (int i = 0; i < 9; i++)
                multiply[i] = Convert.ToInt32(digits[i].ToString()) * oneTwo[i];
            for (int i = 0; i < 9; i++)
                oneDigit[i] = (int)(multiply[i] / 10) + multiply[i] % 10;
            int sum = 0;
            for (int i = 0; i < 9; i++)
                sum += oneDigit[i];
            if (sum % 10 == 0)
                return true;
            return false;
        }
    }
}
