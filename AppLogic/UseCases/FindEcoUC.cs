using AppLogic.UCInterfaces;
using Domain.Entities;
using Domain.RepositoryInterfaces;
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
    public class FindEcoUC : IFindEcosystem
    {
        public IRepositoryEcosystems EcosRepo { get; set; }

        public FindEcoUC(IRepositoryEcosystems repo)
        {
            EcosRepo = repo;
        }
        
        public Ecosystem FindEco(int id) 
        {
            return EcosRepo.Find(id);
        }
    }
}