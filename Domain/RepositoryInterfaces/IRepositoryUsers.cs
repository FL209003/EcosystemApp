using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RepositoryInterfaces
{
    public interface IRepositoryUsers : IRepository<User>
    {
        bool CompareHash(string rawData, string username);
        User FindByName(string username);
    }
}
