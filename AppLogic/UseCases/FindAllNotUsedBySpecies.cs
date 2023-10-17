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
    public class FindAllNotUsedBySpeciesUC : IFindAllNotUsedBySpecies
    {
        public IRepositoryEcosystems EcoRepo { get; set; }

        public FindAllNotUsedBySpeciesUC(IRepositoryEcosystems repo)
        {
            EcoRepo = repo;
        }
        public IEnumerable<Ecosystem> FindAllNotUsedBySpecies(Species s)
        {
            return EcoRepo.FindAllNotUsedBySpecies(s);
        }
    }
}
