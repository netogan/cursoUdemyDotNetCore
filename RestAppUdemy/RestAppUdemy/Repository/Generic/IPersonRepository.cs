using RestAppUdemy.Model;
using System.Collections.Generic;

namespace RestAppUdemy.Repository.Generic
{
    public interface IPersonRepository : IRepository<Person>
    {
        List<Person> FindByName(string firstName, string lastName);
    }
}
