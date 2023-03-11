// <copyright file="RepositoryAutor.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BrowserTravel.Entities;
    using BrowserTravel.Services.Interfaces;
    using Microsoft.EntityFrameworkCore;

    public class RepositoryAutor : IRepositoryAutor
    {
        private readonly ApplicationDBContext dbContext;

        public RepositoryAutor(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(Autor autor)
        {
            await this.dbContext.AddAsync(autor);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<Autor> GetById(int id)
        {
            return await this.dbContext.Autores.Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Autor>> GetAll()
        {
            return await this.dbContext.Autores.ToListAsync();
        }

        public async Task<bool> Exists(string name, string lastname)
        {
            return await this.dbContext.Autores.AnyAsync(a => a.Nombre.Equals(name) && a.Apellido.Equals(lastname));
        }

        public async Task Update(Autor autor)
        {
            this.dbContext.Entry(autor).State = EntityState.Modified;
            await this.dbContext.SaveChangesAsync();
        }

        public async Task Delete(Autor autor)
        {
            this.dbContext.Autores.Remove(autor);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
