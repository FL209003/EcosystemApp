using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLogic.Repositories
{
    public class CountriesRepository : IRepositoryCountries
    {
        public void Add(Country obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Country> FindAll()
        {
            throw new NotImplementedException();
        }

        public Country FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Country obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Country obj)
        {
            throw new NotImplementedException();
        }
    }
}
