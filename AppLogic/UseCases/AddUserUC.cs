using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosUso
{
    public class AddUserUC : IAddUser
    {
        public IRepositoryGenericUsers UsersRepo { get; set; }

        public AddUserUC(IRepositoryGenericUsers repo)
        {
            UsersRepo = repo;
        }

        public void Add(GenericUser user)
        {
            UsersRepo.Add(user);
        }
    }
}
