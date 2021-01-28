using NUnit.Framework;
using System.Xml.Linq;

namespace Kata12
{
    //Given a string of digits, you should replace any digit below 5 with '0' and any digit 5 and above with '1'. Return the resulting string.


    public class Kata
    {
        public static string FakeBin(string x)
        {
            char[] array = x.ToCharArray();
            string result = "";
            int five = '5';
            for (int i = 0; i < array.Length; i++)
            {
                if(x[i] < five)
                {
                    result += 0;
                }
                else
                {
                    result += 1;
                }
            }
            return result;
        }
    }
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("01011110001100111", Kata.FakeBin("45385593107843568"));
            Assert.AreEqual("101000111101101", Kata.FakeBin("509321967506747"));
            Assert.AreEqual("011011110000101010000011011", Kata.FakeBin("366058562030849490134388085"));
        }
    }
}