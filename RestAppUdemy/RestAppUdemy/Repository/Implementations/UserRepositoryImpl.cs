using System.Linq;
using RestAppUdemy.Model;
using RestAppUdemy.Model.Context;

namespace RestAppUdemy.Repository.Implementations
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly MySQLContext _context;

        public UserRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        public User FindByLogin(string login)
        {
            return _context.Users.SingleOrDefault(u => u.Login == login);
        }
    }
}
