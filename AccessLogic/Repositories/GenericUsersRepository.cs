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
    public class GenericUsersRepository : IRepositoryGenericUsers
    {
        public EcosystemContext Context { get; set; }

        public GenericUsersRepository(EcosystemContext context)
        {
            Context = context;
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
                Context.GenericUsers.Add(obj);
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
    }
}
