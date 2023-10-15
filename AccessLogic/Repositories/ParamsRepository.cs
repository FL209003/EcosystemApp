using Domain.Params;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AccessLogic.Repositories
{
    public class ParamsRepository : IRepositoryParams
    {
        public EcosystemContext Context { get; set; }

        public ParamsRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(Limit obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Limit> FindAll()
        {
            throw new NotImplementedException();
        }

        public Limit FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Limit? FindParam(string name)
        {
            return Context.Limits.Where(par => par.Name == name).SingleOrDefault();
        }

        public string? FindValue(string name)
        {
            var value = Context.Limits
                        .Where(par => par.Name == name)
                        .Select(par => par.Value)
                        .SingleOrDefault();
            return value;
        }

        public void Remove(Limit obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Limit p)
        {
            throw new NotImplementedException();
        }
    }
}
