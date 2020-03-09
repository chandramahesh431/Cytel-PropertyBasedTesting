using System;
using Xunit;
using Reservation;
using FsCheck.Xunit;
using FsCheck;
using System.Net.Mail;

namespace XUnitTestProject1
{ 


    public static class FizzBuzzGenerator
    {
        public static Arbitrary<int> Generate()
        {
            return Arb.Default.Int32().Filter(x => x % 3 == 0 && x % 5 == 0);
        }
    }
    public static class FizzGenerator
    {
        public static Arbitrary<int> Generate()
        {
            return Arb.Default.Int32().Filter(x => x % 3 == 0);
        }
    }

    public static class BuzzGenerator
    {
        public static Arbitrary<int> Generate()
        {
            return Arb.Default.Int32().Filter(x => x % 5 == 0);
        }
    }

    public class Fizz
    {
        public static string Buzz(int input)
        {
            if (input % 15 == 0)
                return "FizzBuzz";

            if (input % 3 == 0)
                return "Fizz";

            if (input % 5 == 0)
                return "Buzz";

            return input.ToString();
        }
    }


    public class UnitTest1
    {
  
        [Theory]
        [InlineData("chandra.gajjala@emids.com")]
        [InlineData("test@gmail.com")]
        [InlineData("test@emids.com")]
        public void CheckEmailFormat_ReturnTrue(string email)
        {           
            var result = EmailService.ImportUser(email);

            Assert.True(result);
        }


        [Theory]
        [InlineData("foo@com")]
        public void CheckEmailFormat_ReturnFalse(string email)
        {
            var result = EmailService.ImportUser(email);

            Assert.True(result);
        }



        [Property]
        public Property ShouldImportValidEmail(MailAddress mailAddress)
        {
          

            var result = EmailService.ImportUser(mailAddress.Address);

            //sole.WriteLine(mailAddress.Address, result);

            return (result == true).ToProperty();
          //  Assert.True(result);
           
        }

        [Property]
        public void StringConact(DateTime a, DateTime b)
        {
            var result = a.Year > b.Year;
           // Assert.True(result);
        }

        [Property(Verbose = true)]
        public void StringConact_user(_user _userinfo)
        {
            var result = _userinfo;
            //Assert.True(result.Length > 3);
        }

        [Property]
        public Property testPropetyMethod(int x,int y)
        {
            Func<bool> property =()=> Math.Min(x, y)==x;
            return property.When(x==y);
        }
       
        public class _user
        {
            public string username { set; get; }
            public string password { set; get; }

            public int age { set; get; }

            public bool isAdmin { set; get; }

            public float income { set; get; }

            public MailAddress emailAddress { set; get; }


        }

        [Property(Arbitrary = new[] { typeof(FizzGenerator) })]
        public Property anything_divisible_by_three_but_not_five_returns_fizz(int input)
        {
            Func<bool> property = () => Fizz.Buzz(input) == "Fizz";

            return property.When(input % 3 == 0 && input % 5 != 0);
        }
        [Property(Arbitrary = new[] { typeof(BuzzGenerator) })]
        public Property anything_divisible_by_five_but_not_three_returns_buzz(int input)
        {
            Func<bool> property = () => Fizz.Buzz(input) == "Buzz";

            return property.When(input % 3 != 0 && input % 5 == 0);
        }

        [Property(Arbitrary = new[] { typeof(FizzBuzzGenerator) })]
        public Property anything_divisible_by_three_and_five_returns_fizzbuzz(int input)
        {

            var actual = Fizz.Buzz(input);

           // Assert.True(actual=="FizzBuzz");

            return (actual == "FizzBuzz").ToProperty();
        }
        [Property]
        public Property anything_not_divisible_by_three_and_five_should_return_value_as_string(int input)
        {
            
            Func<bool> property = () => Fizz.Buzz(input) == input.ToString();

            return property.When(input % 3 != 0 && input % 5 != 0).Label($"Failed on input {input}");
        }



    }
}
