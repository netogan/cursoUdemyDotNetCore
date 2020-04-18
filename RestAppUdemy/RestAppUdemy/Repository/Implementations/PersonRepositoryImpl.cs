﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestAppUdemy.Model;
using RestAppUdemy.Model.Context;

namespace RestAppUdemy.Repository.Implementations
{
    public class PersonRepositoryImpl : IPersonRepository
    {
        private MySQLContext _context;

        public PersonRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public void Delete(long id)
        { 
            var res = _context.Persons.SingleOrDefault(p => p.Id == id);

            try
            {
                if (res != null)
                    _context.Persons.Remove(res);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            var res = _context.Persons.ToList();

            return res;
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id))
                return null;

            var res = _context.Persons.SingleOrDefault(p => p.Id == person.Id);

            try
            {
                _context.Entry(res).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id == id);
        }
    }
}
