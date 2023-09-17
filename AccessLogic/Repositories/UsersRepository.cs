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

        public void Add(Admin obj)
        {
            if (obj != null)
            {
                obj.Validate();
                //OTRAS VALIDACIONES ADICIONALES:
                //EMAIL REPETIDO
                //PAIS NO EXISTE 
                //ETC

                //Context.Entry(obj).State = EntityState.Unchanged;
                Context.Admins.Add(obj);
                Context.SaveChanges();
            }
            else throw new Exception("");
        }
        public void Add(GenericUser obj)
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

        public void Remove(GenericUser obj)
        {
            throw new NotImplementedException();
        }

        public void Update(GenericUser obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GenericUser> FindAll()
        {
            throw new NotImplementedException();
        }

        public GenericUser FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Admin obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Admin obj)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Admin> IRepository<Admin>.FindAll()
        {
            throw new NotImplementedException();
        }

        Admin IRepository<Admin>.FindById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
