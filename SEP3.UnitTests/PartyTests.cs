using System;
using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
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
        public void PartyDescription_Working_True()
        {
            Party party = new Party("Best party","so cool","home", "223");
            String s = "so cool";
            
                bool coolParty = party.description.Equals(s);
                Assert.True(coolParty);
                
            
            
        }
        [Test]
        public void PartyTitle_Working_True()
                 {
                     Party party = new Party("Best party","so cool","home", "223");
                     String s = "Best party";
            
                     bool coolParty = party.partyTitle.Equals(s);
                     Assert.True(coolParty);
                 }
        [Test]
        public void PartyID_Working_True()
                 {
                     Party party = new Party("Best party","so cool","home", "223");
                     String s = "223";
            
                     bool coolParty = party.partyID.Equals(s);
                     Assert.True(coolParty);
                 }
        [Test]
        public void PartyDate_Working_True()
        {
            Party party = new Party("Best party","so cool","home", "223");
            
            
            bool coolParty = party.Date == null;
            Assert.True(coolParty);
        }
        [Test]
        public void Partytime_Working_True()
        {
            Party party = new Party("Best party","so cool","home", "223");
            
            
            bool coolParty = party.Time == null;
            Assert.True(coolParty);
        }
        [Test]
        public void PartyLocation_Working_True()
        {
            Party party = new Party("Best party","so cool","home", "223");
            String s = "home";
            
            bool coolParty = party.location.Equals(s);
            Assert.True(coolParty);
        }
        [Test]
        public void PartyItemList_Working_True()
        {
            Party party = new Party("Best party","so cool","home", "223");
            party.Items = new List<Item>() ;
            List<Item> testList = new List<Item>();
            Item item1 = new Item();
            party.Items.Add(item1);
            testList.Add(item1);
            bool coolParty = testList[0].Equals(party.Items[0]);
            Assert.True(coolParty);
        }
        [Test]
        public void PartyPeopleList_Working_True()
                 {
                     Party party = new Party("Best party","so cool","home", "223");
                     party.Attendants = new List<Person>() ;
                     List<Person> testList = new List<Person>();
                     Person person1 = new Person();
                     party.Attendants.Add(person1);
                     testList.Add(person1);
                     bool coolParty = testList[0].Equals(party.Attendants[0]);
                     Assert.True(coolParty);
                 }
  
    }
}