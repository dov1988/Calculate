using NUnit.Framework;
using System.Collections.Generic;

namespace Kata10
{
    //In this simple exercise, you will build a program that takes a value, integer, and returns a list of its multiples up to another value, limit.If limit is a multiple of integer, it should be included as well.There will only ever be positive integers passed into the function, not consisting of 0. The limit will always be higher than the base.
    //For example, if the parameters passed are (2, 6), the function should return [2, 4, 6] as 2, 4, and 6 are the multiples of 2 up to 6.
    //If you can, try writing it in only one line of code.
    public class Kata
    {
        public static List<int> FindMultiples(int integer, int limit)
        {
            List<int> multiples = new List<int>();
            for (int i = integer; i <= limit; i++)
            {
                if (i % integer == 0)
                {
                    multiples.Add(i);
                }
            }
            return multiples;
        }
    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SampleTest()
        {
            Assert.AreEqual(new List<int> { 5, 10, 15, 20, 25 }, Kata.FindMultiples(5, 25));
            Assert.AreEqual(new List<int> { 1, 2 }, Kata.FindMultiples(1, 2));
        }
    }
}