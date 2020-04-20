using RestAppUdemy.Data.VO;
using RestAppUdemy.Model;
using System.Collections.Generic;

namespace RestAppUdemy.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        List<BookVO> FindAll();
        BookVO Update(BookVO book);
        void Delete(long id);
    }
}
