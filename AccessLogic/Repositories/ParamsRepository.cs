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

        public void Add(Param obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Param> FindAll()
        {
            throw new NotImplementedException();
        }

        public Param FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Param? FindParam(string name)
        {
            return Context.Params.Where(par => par.Name == name).SingleOrDefault();
        }

        public string? FindValue(string name)
        {
            var value = Context.Params
                        .Where(par => par.Name == name)
                        .Select(par => par.Value)
                        .SingleOrDefault();

            return value;
        }

        public void Remove(Param obj)
        {
            throw new NotImplementedException();
        }

        public void Update(Param obj)
        {
            throw new NotImplementedException();
        }
    }
}
