using Domain.Entities;
using Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessLogic.Repositories
{
    public class EcosystemsRepository : IRepositoryEcosystems
    {
        public EcosystemContext Context { get; set; }

        public EcosystemsRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(Ecosystem e)
        {
            if (e != null) {
                try {                
                    e.Validate();
                    Context.Ecosystems.Add(e);
                    Context.SaveChanges();                
                } catch (Exception ex) {
                    throw ex;
                }  
            } throw new InvalidOperationException("Error al crear un ecosistema, intente nuevamente.");
        }

        public IEnumerable<Ecosystem> FindAll()
        {
            return Context.Ecosystems.ToList();
        }

        public Ecosystem FindById(int id)
        {
            Ecosystem e = Context.Ecosystems.Find(id);
            if (e != null) {
                return e;
            } throw new InvalidOperationException("No se encontró un ecosistema con ese id.");
        }

        public void Remove(Ecosystem e)
        {
            if (e != null) {
                if (e.Species == null) {
                    try {                  
                        Context.Ecosystems.Remove(e);
                        Context.SaveChanges();                                          
                    } catch (Exception ex) {
                        throw ex;
                    } 
                } else throw new InvalidOperationException("El ecosistema no debe tener especies que lo habiten para poder eliminarlo.");              
            } else throw new InvalidOperationException("El ecosistema que intenta eliminar no existe.");
        }

        public void Update(Ecosystem e)
        {
            if (e != null) {
                Context.Ecosystems.Update(e);
                Context.SaveChanges();
            } throw new InvalidOperationException("El ecosistema que intenta actualizar no existe.");
        }
    }
}
