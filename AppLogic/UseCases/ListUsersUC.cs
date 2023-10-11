using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCases
{
    public class ListUsersUC : IListUser
    {
        public IRepositoryUsers UsersRepo { get; set; }

        public ListUsersUC(IRepositoryUsers repo)
        {
            UsersRepo = repo;
        }
        
        public List<User> List() 
        {
            return UsersRepo.FindAll().ToList();
        }
    }
}
