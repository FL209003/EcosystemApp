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
    public class ListSpeciesUC : IListSpecies
    {
        public IRepositorySpecies SpeciesRepo { get; set; }

        public ListSpeciesUC(IRepositorySpecies repo)
        {
            SpeciesRepo = repo;
        }

        public List<Species> List()
        {
            return SpeciesRepo.FindAll().ToList();
        }
    }
}
