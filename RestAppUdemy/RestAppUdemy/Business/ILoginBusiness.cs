using RestAppUdemy.Data.VO;

namespace RestAppUdemy.Business
{
    public interface ILoginBusiness
    {
        object FindByLogin(UserVO user);
    }
}
