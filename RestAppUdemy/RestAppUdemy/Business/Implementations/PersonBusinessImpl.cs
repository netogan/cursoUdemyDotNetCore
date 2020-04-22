using System.Collections.Generic;
using RestAppUdemy.Data.Converters;
using RestAppUdemy.Data.VO;
using RestAppUdemy.Repository.Generic;
using Tapioca.HATEOAS.Utils;

namespace RestAppUdemy.Business.Implementations
{
    public class PersonBusinessImpl : IPersonBusiness
    {
        private IPersonRepository _repository;

        private readonly PersonConverter _converter;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);

            personEntity = _repository.Create(personEntity);

            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<PersonVO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonVO Update(PersonVO person)
        {
            var personEntity = _converter.Parse(person);

            personEntity = _repository.Update(personEntity);

            return _converter.Parse(personEntity);
        }

        public List<PersonVO> FindByName(string firstName, string lastName)
        {
            return _converter.ParseList(_repository.FindByName(firstName, lastName));
        }

        public PagedSearchDTO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page)
        {
            page = page > 0 ? page - 1 : 0;

            var sql = $"SELECT * FROM Persons p WHERE 1 = 1 ";
            var countSql = $"SELECT COUNT(*) FROM Persons p WHERE 1 = 1 ";

            if (!string.IsNullOrEmpty(name))
            {
                sql += $"AND p.FirstName LIKE '%{name}%' ";
                countSql += $"AND p.FirstName LIKE '%{name}%' ";
            }

            sql += $"ORDER BY FirstName {sortDirection} LIMIT {pageSize} OFFSET {page}";
            countSql += $"ORDER BY FirstName {sortDirection} ";

            var persons = _converter.ParseList(_repository.FindWithPagedSearch(sql));
            var totalResult = _repository.GetCount(countSql);

            return new PagedSearchDTO<PersonVO>
            {
                CurrentPage = page + 1,
                List = persons,
                PageSize = pageSize,
                SortDirections = sortDirection,
                TotalResults = totalResult
            };
        }
    }
}
