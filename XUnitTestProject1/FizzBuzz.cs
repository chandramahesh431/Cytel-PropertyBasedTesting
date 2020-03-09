using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace XUnitTestProject1
{
	public class FizzBuzz
	{
		

		public string FizzyOutput(int input)
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

	[TestFixture]
	public class FizzBuzzTests
	{
		private FizzBuzz fizzBuzz;

		[SetUp]
		public void Setup()
		{
			fizzBuzz = new FizzBuzz();
		}

		[Test]
		public void FizzyOutput_OutputsOne_WhenInputIsOne()
		{
			var output = fizzBuzz.FizzyOutput(1);

			Assert.AreEqual("1", output);
		}

		[Test]
		public void FizzyOutput_OutputsTwo_WhenInputIsTwo()
		{
			var output = fizzBuzz.FizzyOutput(2);

			Assert.AreEqual("2", output);
		}

		[TestCase(3)]
		[TestCase(6)]
		[TestCase(9)]
		public void FizzyOutput_OutputsFizz_WhenInputIsMultipleOfThree(int input)
		{
			var output = fizzBuzz.FizzyOutput(input);

			Assert.AreEqual("Fizz", output);
		}

		[TestCase(5)]
		[TestCase(10)]
		public void FizzyOutput_OutputsBuzz_WhenInputIsMultipleOfFive(int input)
		{
			var output = fizzBuzz.FizzyOutput(input);

			Assert.AreEqual("Buzz", output);
		}

		[TestCase(15)]
		[TestCase(30)]
		[TestCase(45)]
		public void FizzyOutput_OutputsFizzBuzz_WhenInputIsMultipleOfThreeAndFive(int input)
		{
			var output = fizzBuzz.FizzyOutput(input);

			Assert.AreEqual("FizzBuzz", output);
		}

		[TestCase(1, "1")]
		[TestCase(2, "2")]
		[TestCase(3, "Fizz")]
		[TestCase(4, "4")]
		[TestCase(5, "Buzz")]
		// ....
		[TestCase(14, "14")]
		[TestCase(15, "FizzBuzz")]
		[TestCase(16, "16")]
		// ...
		[TestCase(95, "Buzz")]
		[TestCase(96, "Fizz")]
		[TestCase(97, "97")]
		[TestCase(98, "98")]
		[TestCase(99, "Fizz")]
		[TestCase(100, "Buzz")]
		public void FizzyOutput_OutputsExpectedValues(int input, string expectedOutput)
		{
			var actualOutput = fizzBuzz.FizzyOutput(input);

			Assert.AreEqual(expectedOutput, actualOutput);
		}
	}

}
