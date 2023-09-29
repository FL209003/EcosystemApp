using Domain.Entities;
using Domain.RepositoryInterfaces;
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
                    Context.Threats.Add(s);
                    Context.SaveChanges();
                } throw new InvalidOperationException("Error al crear una especie, intente nuevamente.");
            } catch (Exception ex) {
                throw ex;
            }  
        }

        public IEnumerable<Species> FindAll()
        {
            return Context.Species.ToList();
        }

        public Species FindById(int id)
        {
            Species s = Context.Species.Find(id);
            if (s != null) {
                return s;
            } throw new InvalidOperationException("No se encontró una especie con ese id.");
        }

        public void Remove(Species s)
        {
            if (s != null) {
                Context.Species.Remove(s);
                Context.SaveChanges();
            } throw new InvalidOperationException("La especie que intenta eliminar no existe.");
        }

        public void Update(Species s)
        {
            if (s != null) {
                Context.Species.Update(s);
                Context.SaveChanges();
            } throw new InvalidOperationException("La especie que intenta actualizar no existe.");
        }
    }
}
