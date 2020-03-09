using NUnit.Framework;
using Reservation;

namespace Reservation.unittest
{
    public class ReservationTests
    {
       [Test]
       public void CanCancelledBy_AdminCancelling_ReturnTrue()
        {
            var reservation = new ReservationClass();

            var result = reservation.CanCancelledBy(new user() { IsAdmin = true });

            Assert.IsTrue(result);
        }
        [Test]
        
        public void CanCancelledBy_SameUserCancelling_ReturnTrue()
        {
            var user = new user();
            var reservation = new ReservationClass { MadeBy=user};

            var result = reservation.CanCancelledBy(user);

            Assert.IsTrue(result);
        }
        [Test]
        public void CanCancelledBy_AnotherUserCancelling_ReturnFalse()
        {
           
            var reservation = new ReservationClass { MadeBy = new user() };

            var result = reservation.CanCancelledBy(new user());

            Assert.IsFalse(result);
        }
    }
}