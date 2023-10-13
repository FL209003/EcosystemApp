using AppLogic.UCInterfaces;
using Domain.Params;
using Domain.RepositoryInterfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic.UseCases
{
    public class ModifyLengthParamUC : IModifyLengthParam
    {
        public IRepositoryParams Repo { get; set; }

        public ModifyLengthParamUC(IRepositoryParams repo)
        {
            Repo = repo;
        }
        public void ModifyNameParams(int newMinLength, int newMaxLength)
        {
            Param minLength = Repo.FindParam("MinLength");
            minLength.Value = newMinLength.ToString();
            Repo.Update(minLength);

            Param maxLength = Repo.FindParam("MaxLength");
            maxLength.Value = newMaxLength.ToString();
            Repo.Update(maxLength);

            Name.MinLength = newMinLength;
            Name.MaxLength = newMaxLength;
        }

        public void ModifyDescParams(int newMinLength, int newMaxLength)
        {
            Param minLength = Repo.FindParam("MinLength");
            minLength.Value = newMinLength.ToString();
            Repo.Update(minLength);

            Param maxLength = Repo.FindParam("MaxLength");
            maxLength.Value = newMaxLength.ToString();
            Repo.Update(maxLength);

            Description.MinLength = newMinLength;
            Description.MaxLength = newMaxLength;
        }
    }
}
