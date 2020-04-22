using RestAppUdemy.Model.Base;
using System.Collections.Generic;

namespace RestAppUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T FindById(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exist(long? id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
