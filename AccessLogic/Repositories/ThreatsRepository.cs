using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLogic.Repositories
{
    public class ThreatsRepository : IRepositoryThreats
    {
        public void Add(Threat obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Threat> FindAll()
        {
            throw new NotImplementedException();
        }

        public Threat FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Threat obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Threat obj)
        {
            throw new NotImplementedException();
        }
    }
}
