using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace text0425_input_output.Models
{
    public class Employee
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }

        public bool IsValid()
        {
            int error = 0;
            if (String.IsNullOrEmpty(this.FirstName))
                error += 1;
            if (String.IsNullOrEmpty(this.LastName))
                error += 1;

            return (error == 0);
        }
    }
}