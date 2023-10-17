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
    public class CompareHashUC : ICompareHash
    {
        public IRepositoryUsers UsersRepo { get; set; }

        public CompareHashUC(IRepositoryUsers repo)
        {
            UsersRepo = repo;
        }

        public bool CompareHash(string rawData, string username)
        {            
            return UsersRepo.CompareHash(rawData, username);
        }
    }
}
