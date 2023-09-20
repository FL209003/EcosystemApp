using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLogic.Repositories
{
    public class UsersRepository : IRepositoryUsers
    {
        public void Add(Admin obj)
        {
            throw new NotImplementedException();
        }

        public void Add(GenericUser obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Admin> FindAll()
        {
            throw new NotImplementedException();
        }

        public Admin FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Admin obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(GenericUser obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Admin obj)
        {
            throw new NotImplementedException();
        }

        public void Update(GenericUser obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<GenericUser> IRepository<GenericUser>.FindAll()
        {
            throw new NotImplementedException();
        }

        GenericUser IRepository<GenericUser>.FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
