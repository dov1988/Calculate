using NUnit.Framework;

namespace Kata13
{
    //    Write a function getDrinkByProfession/get_drink_by_profession() that receives as input parameter a string, and produces outputs according to the following table:
    //Input Output
    //"Jabroni"	"Patron Tequila"
    //"School Counselor"	"Anything with Alcohol"
    // "Programmer"	 "Hipster Craft Beer"
    // "Bike Gang Member"	"Moonshine" 
    // "Politician"	"Your tax dollars" 
    // "Rapper"	"Cristal" 
    // * anything else*	"Beer" 
    //Note: anything else is the default case: if the input to the function is not any of the values in the table, then the return value should be "Beer."
    //Make sure you cover the cases where certain words do not show up with correct capitalization.For example, getDrinkByProfession("pOLitiCIaN") should still return "Your tax dollars".
    public class Kata
    {
        public static string GetDrinkByProfession(string p)
        {
            if(p.ToLower() == "Jabroni".ToLower())
            {
                return "Patron Tequila";
            }
            else if (p.ToLower() == "School Counselor".ToLower())
            {
                return "Anything with Alcohol";
            }
            else if (p.ToLower() == "Programmer".ToLower())
            {
                return "Hipster Craft Beer";
            }
            else if (p.ToLower() == "Bike Gang Member".ToLower())
            {
                return "Moonshine";
            }
            else if (p.ToLower() == "Politician".ToLower())
            {
                return "Your tax dollars";
            }
            else if (p.ToLower() == "Rapper".ToLower())
            {
                return "Cristal";
            }
            else 
            {
                return "Beer";
            }
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
            Assert.AreEqual("Patron Tequila", Kata.GetDrinkByProfession("jabrOni"), "'Jabroni' should map to 'Patron Tequila'");
            Assert.AreEqual("Anything with Alcohol", Kata.GetDrinkByProfession("scHOOl counselor"), "'School Counselor' should map to 'Anything with alcohol'");
            Assert.AreEqual("Hipster Craft Beer", Kata.GetDrinkByProfession("prOgramMer"), "'Programmer' should map to 'Hipster Craft Beer'");
            Assert.AreEqual("Moonshine", Kata.GetDrinkByProfession("bike ganG member"), "'Bike Gang Member' should map to 'Moonshine'");
            Assert.AreEqual("Your tax dollars", Kata.GetDrinkByProfession("poLiTiCian"), "'Politician' should map to 'Your tax dollars'");
            Assert.AreEqual("Cristal", Kata.GetDrinkByProfession("rapper"), "'Rapper' should map to 'Cristal'");
            Assert.AreEqual("Beer", Kata.GetDrinkByProfession("pundit"), "'Pundit' should map to 'Beer'");
            Assert.AreEqual("Beer", Kata.GetDrinkByProfession("Pug"), "'Pug' should map to 'Beer'");
        }
    }
}