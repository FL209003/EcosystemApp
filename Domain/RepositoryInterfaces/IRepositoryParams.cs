using Domain.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepositoryParams : IRepository<Param>
    {
        string? FindValue(string name);
        Param? FindParam(string name);
    }
}
