using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AccessLogic.Repositories
{
    public class UsersRepository : IRepositoryUsers
    {
        public EcosystemContext Context { get; set; }

        public UsersRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(User user)
        {
            if (user != null)
            {
                Context.Users.Add(user);
                Context.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("No se provee información del cliente");
            }
        }

        public IEnumerable<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public User FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(User obj)
        {
            throw new NotImplementedException();
        }

        public void Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
