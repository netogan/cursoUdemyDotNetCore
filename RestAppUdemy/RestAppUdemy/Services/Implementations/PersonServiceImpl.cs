using System;
using System.Collections.Generic;
using System.Threading;
using RestAppUdemy.Model;

namespace RestAppUdemy.Services.Implementations
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for(int i = 0; i < 8; i++)
            {
                Person p = MockPerson(i);
                persons.Add(p);
            }

            return persons;
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name " + i,
                LastName = "Person LastName " + i,
                Address = "Some Address " + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }

        public Person FindById(long id)
        {
            return new Person()
            {
                Id = 1,
                FirstName = "João",
                LastName = "Da Silva",
                Address = "Av. Sergipe",
                Gender = "Masculino"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
