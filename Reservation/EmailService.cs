using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Reservation
{
    public class EmailService
    {
        private const string EmailPattern =
            @"^(?![\.@])(""([^""\r\\]|\\[""\r\\])*""|([-\p{L}0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@([a-z0-9][\w-]*\.)+[a-z]{2,}$";

        public static bool ImportUser(string email)
        {
            if (!string.IsNullOrEmpty(email) && !Regex.IsMatch(email, EmailPattern))
            {
                return false;
            }
            return true;
        }
    }
}
