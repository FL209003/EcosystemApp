using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLogic.Repositories
{
    public class UsersRepository : IRepositoryUsers
    {
        public EcosystemContext Context { get; set; }

        public UsersRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(User obj)
        {
            if (obj != null)
            {
                obj.Validate();
                //OTRAS VALIDACIONES ADICIONALES:
                //EMAIL REPETIDO
                //PAIS NO EXISTE 
                //ETC

                //Context.Entry(obj).State = EntityState.Unchanged;
                Context.Users.Add(obj);
                Context.SaveChanges();
            }
            else throw new Exception("");
        }

        public void Remove(User obj)
        {
            throw new NotImplementedException();
        }

        public void Update(User obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> FindAll()
        {
            throw new NotImplementedException();
        }

        public User FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
