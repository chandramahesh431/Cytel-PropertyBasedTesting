using System;

namespace Reservation
{
    public class ReservationClass
    {
        public user MadeBy { set; get; }

        public bool CanCancelledBy(user user)
        {
            if (user.IsAdmin || MadeBy == user)
            {
                return true;
            }          
            return false;
        }

    }

    public class user
    {
        public bool IsAdmin { set; get; }
    }
}
