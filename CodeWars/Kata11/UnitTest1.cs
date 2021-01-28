using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Kata11
{
    //    When it's spring Japanese cherries blossom, it's called "sakura" and it's admired a lot. The petals start to fall in late April.
    //Suppose that the falling speed of a petal is 5 centimeters per second(5 cm/s), and it takes 80 seconds for the petal to reach the ground from a certain branch.
    //Write a function that receives the speed (in cm/s) of a petal as input, and returns the time it takes for that petal to reach the ground from the same branch.
    //Notes:
    //The movement of the petal is quite complicated, so in this case we can see the velocity as a constant during its falling.
    //Pay attention to the data types.
    //If the initial velocity is non-positive, the return value should be 0
    public static class Kata
    {
        public static double SakuraFall(double v)
        {
            if(v > 0)
            {
                double distance = 80 * 5;
                return distance / v;
            }
            else
            {
                return 0;
            }
        }
    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestFixture]
        public class SampleTest
        {
            private static IEnumerable<TestCaseData> testCases
            {
                get
                {
                    yield return new TestCaseData(5).Returns(80);
                }
            }

            [Test, TestCaseSource("testCases")]
            public double Test(double v) =>
              Kata.SakuraFall(v);
        }
    }
}
