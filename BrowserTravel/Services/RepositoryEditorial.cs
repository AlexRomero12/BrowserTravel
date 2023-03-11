// <copyright file="RepositoryEditorial.cs" company="Alexander Romero">
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

    public class RepositoryEditorial : IRepositoryEditorial
    {
        private readonly ApplicationDBContext dbContext;

        public RepositoryEditorial(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task Create(Editorial editorial)
        {
            await this.dbContext.AddAsync(editorial);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task Delete(Editorial editorial)
        {
            this.dbContext.Editoriales.Remove(editorial);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exists(string nombre, string sede)
        {
            return await this.dbContext.Autores.AnyAsync(a => a.Nombre.Equals(nombre) && a.Apellido.Equals(sede));
        }

        public async Task<List<Editorial>> GetAll()
        {
            return await this.dbContext.Editoriales.ToListAsync();
        }

        public async Task<Editorial> GetById(int id)
        {
            return await this.dbContext.Editoriales.Where(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task Update(Editorial editorial)
        {
            this.dbContext.Entry(editorial).State = EntityState.Modified;
            await this.dbContext.SaveChangesAsync();
        }
    }
}
