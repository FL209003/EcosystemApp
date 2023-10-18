using Domain.Entities;
using Domain.RepositoryInterfaces;
using Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLogic.Repositories
{
    public class SpeciesRepository : IRepositorySpecies
    {
        public EcosystemContext Context { get; set; }

        public SpeciesRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(Species s)
        {
            try
            {
                if (s != null)
                {
                    s.Validate();
                    Context.Species.Add(s);
                    Context.SaveChanges();
                }
                else throw new SpeciesException("Error al crear una especie, intente nuevamente.");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IEnumerable<Species> FindAll()
        {
            return Context.Species;
        }

        public Species FindById(int id)
        {
            Species? s = Context.Species
                .Include(s => s.Ecosystems)
                .ThenInclude(e => e.Threats)
                .Include(e => e.Threats)
                .FirstOrDefault(s => s.Id == id);
            if (s != null)
            {
                return s;
            }
            else throw new SpeciesException("No se encontró una especie con ese id.");
        }

        public void Remove(Species s)
        {
            if (s != null)
            {
                Context.Species.Remove(s);
                Context.SaveChanges();
            }
            else throw new SpeciesException("La especie que intenta eliminar no existe.");
        }

        public void Update(Species s)
        {
            if (s != null)
            {
                Context.Species.Update(s);
                Context.SaveChanges();
            }
            else throw new SpeciesException("La especie que intenta actualizar no existe.");
        }

        object IRepositorySpecies.FindByCientificName()
        {
            throw new NotImplementedException();
        }

        object IRepositorySpecies.FindByDangerOfExtinction()
        {
            throw new NotImplementedException();
        }

        object IRepositorySpecies.FindByWeight()
        {
            throw new NotImplementedException();
        }

        object IRepositorySpecies.FindByEco()
        {
            throw new NotImplementedException();
        }
    }
}
