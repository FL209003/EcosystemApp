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
    public class FindConservationBySecUC : IFindConservationBySec
    {
        public IRepositoryConservations ConsRepo { get; set; }

        public FindConservationBySecUC(IRepositoryConservations repo)
        {
            ConsRepo = repo;
        }
        public Conservation FindBySecutiry(int sec)
        {
            return ConsRepo.FindBySecurity(sec);
        }
    }
}
