using NUnit.Framework;
using SEP3.Models;

namespace SEP3.UnitTests
{
    [TestFixture]
    public class PartyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ToString_Working_True()
        {
            Party party = new Party();

            party.description = "Cool party";
            Assert.Pass();
        }
    }
}