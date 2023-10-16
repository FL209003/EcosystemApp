using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UCInterfaces
{
    public interface IFindConservationBySec
    {
        Conservation FindBySecutiry(int sec);
    }
}
