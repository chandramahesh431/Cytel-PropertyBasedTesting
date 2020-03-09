using System;
using Reservation;

namespace PropertyBasedTesting
{
  
    class Program
    {
        ReservationClass obj = new ReservationClass();

       
        
        user userObj = new user();
        

        static void Main(string[] args)
        {

            Console.WriteLine(MD5.MD5Hash("foo"));
        }
    }
}
