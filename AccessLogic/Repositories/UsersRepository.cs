﻿using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace AccessLogic.Repositories
{
    public class UsersRepository : IRepositoryUsers
    {
        public EcosystemContext Context { get; set; }

        public UsersRepository(EcosystemContext context)
        {
            Context = context;
        }

        public void Add(User u)
        {
            try
            {
                if (u != null)
                {
                    user.Validate();
                    Context.Users.Add(u);
                    Context.SaveChanges();
                } throw new InvalidOperationException("Error al crear usuario, intente nuevamente.");
            } catch (Exception ex) {
                throw ex;
            }       
        }

        public IEnumerable<User> FindAll()
        {
            return Context.Users.ToList();
        }

        public User FindById(int id)
        {
            User user = Context.Users.Find(id);
            if (user != null) {
                return user;
            } throw new InvalidOperationException("No se encontró un usuario con ese id.");
        }

        public void Remove(User u)
        {
            if (u != null) {
                Context.Users.Remove(u);
                Context.SaveChanges();
            } throw new InvalidOperationException("El usuario que intenta eliminar no existe.");
        }

        public void Update(User u)
        {
            if (u != null) {
                Context.Users.Update(u);
                Context.SaveChanges();
            } throw new InvalidOperationException("El usuario que intenta actualizar no existe.");
        }
    }
}
 