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
            Party party = new Party();
            party.partyTitle = "Best party";
            party.date = "29/11/2019";
            party.description = "so cool";
            party.location = "home";
            party.time = "22:30";
            
            String s = "so cool";
            
                bool coolParty = party.description.Equals(s);
                Assert.True(coolParty);
                
            
            
        }
        [Test]
        public void PartyTitle_Working_True()
                 {
                     Party party = new Party();
                     party.partyTitle = "Best party";
                     party.date = "29/11/2019";
                     party.description = "so cool";
                     party.location = "home";
                     party.time = "22:30"; 
                     String s = "Best party";
            
                     bool coolParty = party.partyTitle.Equals(s);
                     Assert.True(coolParty);
                 }
        [Test]
        public void PartyID_Working_True()
                 {
                     Party party = new Party();
                     party.partyTitle = "Best party";
                     party.date = "29/11/2019";
                     party.description = "so cool";
                     party.location = "home";
                     party.time = "22:30";
                     String s = "223";
            
                     bool coolParty = party.partyID.Equals(s);
                     Assert.True(coolParty);
                 }
        [Test]
        public void PartyDate_Working_True()
        {
            Party party = new Party();
            party.partyTitle = "Best party";
            party.date = "29/11/2019";
            party.description = "so cool";
            party.location = "home";
            party.time = "22:30";
            
            
            bool coolParty = party.date == null;
            Assert.True(coolParty);
        }
        [Test]
        public void Partytime_Working_True()
        {
            Party party = new Party();
            party.partyTitle = "Best party";
            party.date = "29/11/2019";
            party.description = "so cool";
            party.location = "home";
            party.time = "22:30";
            
            
            bool coolParty = party.time == null;
            Assert.True(coolParty);
        }
        [Test]
        public void PartyLocation_Working_True()
        {
            Party party = new Party();
            party.partyTitle = "Best party";
            party.date = "29/11/2019";
            party.description = "so cool";
            party.location = "home";
            party.time = "22:30";
            String s = "home";
            
            bool coolParty = party.location.Equals(s);
            Assert.True(coolParty);
        }
        [Test]
        public void PartyItemList_Working_True()
        {
            Party party = new Party();
            party.partyTitle = "Best party";
            party.date = "29/11/2019";
            party.description = "so cool";
            party.location = "home";
            party.time = "22:30";
            party.items = new List<Item>() ;
            List<Item> testList = new List<Item>();
            Item item1 = new Item();
            party.items.Add(item1);
            testList.Add(item1);
            bool coolParty = testList[0].Equals(party.items[0]);
            Assert.True(coolParty);
        }
        [Test]
        public void PartyPeopleList_Working_True()
                 {
                     Party party = new Party();
                     party.partyTitle = "Best party";
                     party.date = "29/11/2019";
                     party.description = "so cool";
                     party.location = "home";
                     party.time = "22:30";
                     
                     party.people = new List<Person>() ;
                     List<Person> testList = new List<Person>();
                     Person person1 = new Person();
                     party.people.Add(person1);
                     testList.Add(person1);
                     bool coolParty = testList[0].Equals(party.people[0]);
                     Assert.True(coolParty);
                 }
  
    }
}