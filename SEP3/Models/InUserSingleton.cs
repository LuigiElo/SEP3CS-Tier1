using System.Collections.Generic;

namespace SEP3.Models
{
    public interface InUserSingleton
    {
        void setUser(Person person);
        Person getUser();

        void setParties(List<Party> parties);
        List<Party> getParties();

        void setActiveParties(Party party);
        Party getActiveParty();

        void setItemsAdded(List<Item> items);
        List<Item> getItemsAdded();
        void setItemsRemoved(List<Item> items);
        List<Item> getItemsRemoved();
        void setPeopleAdded(List<Person> persons);
        List<Person> getPeopleAdded();
        void setPeopleRemoved(List<Person> persons);
        List<Person> getPeopleRemoved();

        void setSearchResult(List<Person> persons);
        List<Person> getSearchResult();

    }
}