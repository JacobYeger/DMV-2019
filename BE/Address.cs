using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
   public struct Address
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public String City { get; set; }

        //prints all details of the address
        public override string ToString()
        {
            string result = "";
            result += string.Format("Street: {0}\n", Street);
            result += string.Format("Number: {0}\n", Number);
            result += string.Format("City: {0}\n", City);
            return result;

        }
    }
}
