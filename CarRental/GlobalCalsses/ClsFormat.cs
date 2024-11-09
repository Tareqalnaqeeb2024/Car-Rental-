using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CarRental.GlobalCalsses
{
   public class ClsFormat
    {
        public static bool ValidatingEmail(string  Email)
        {
            var Pattern = @"^[a-zA-Z0-9..!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            var RegEx = new Regex(Pattern);

            return RegEx.IsMatch(Email);
        }

    }
}
