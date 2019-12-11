using System.Collections.Generic;

namespace SEP3.Models
{
    public interface InUserSingleton
    {
        void setUser(Person person);
        Person getUser();

        void setParties(List<Party> parties);
        List<Party> getParties();
    }
}