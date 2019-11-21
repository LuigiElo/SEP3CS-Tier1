using System.Collections.Generic;
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
            Party party = new Party();
        }

        [Test]
        public void PartyDescription_Working_True(Party party)
        {
            party.description = "Cool party";
            bool coolParty = "Cool party" == party.description;
            Assert.True(coolParty);
        }
        public void PartyTitle_Working_True(Party party)
                 {
                     party.partyTitle= "party";
                     bool coolParty = "party" == party.partyTitle;
                     Assert.True(coolParty);
                 }
        public void PartyID_Working_True(Party party)
                 {
                     party.partyID= "223";
                     bool coolParty = "223" == party.partyID;
                     Assert.True(coolParty);
                 }
        public void PartyDate_Working_True(Party party)
        {
            party.Date= "223";
            bool coolParty = "223" == party.Date;
            Assert.True(coolParty);
        }
        public void Partytime_Working_True(Party party)
        {
            party.Time= "223";
            bool coolParty = "223" == party.Time;
            Assert.True(coolParty);
        }
        public void PartyLocation_Working_True(Party party)
        {
            party.location= "home";
            bool coolParty = "home" == party.location;
            Assert.True(coolParty);
        }
        public void PartyItemList_Working_True(Party party)
        {
            party.Items = new List<Item>() ;
            List<Item> testList = new List<Item>();
            Item item1 = new Item();
            party.Items.Add(item1);
            testList.Add(item1);
            bool coolParty = testList.Equals(party.Items);
            Assert.True(coolParty);
        }
        public void PartyPeopleList_Working_True(Party party)
                 {
                     party.Attendants = new List<Person>() ;
                     List<Person> testList = new List<Person>();
                     Person person1 = new Person();
                     party.Attendants.Add(person1);
                     testList.Add(person1);
                     bool coolParty = testList.Equals(party.Attendants);
                     Assert.True(coolParty);
                 }
        
        
        
        
    }
}