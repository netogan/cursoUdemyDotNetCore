using RestAppUdemy.Data.VO;
using RestAppUdemy.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestAppUdemy.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        Task<List<BookVO>> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
