using RestAppUdemy.Model;
using System.Collections.Generic;

namespace RestAppUdemy.Repository
{
    public interface IUserRepository
    {
        User FindByLogin(string login);
    }
}
