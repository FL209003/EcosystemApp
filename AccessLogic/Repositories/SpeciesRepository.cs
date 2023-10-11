using Domain.Entities;
using Domain.RepositoryInterfaces;
using Exceptions;
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
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<Species> FindAll()
        {
            return Context.Species.ToList();
        }

        public Species FindById(int id)
        {
            Species? s = Context.Species.Find(id);
            if (s != null)
            {
                return s;
            }
            throw new SpeciesException("No se encontró una especie con ese id.");
        }

        public void Remove(Species s)
        {
            if (s != null)
            {
                Context.Species.Remove(s);
                Context.SaveChanges();
            }
            throw new SpeciesException("La especie que intenta eliminar no existe.");
        }

        public void Update(Species s)
        {
            if (s != null)
            {
                Context.Species.Update(s);
                Context.SaveChanges();
            }
            throw new SpeciesException("La especie que intenta actualizar no existe.");
        }
    }
}
