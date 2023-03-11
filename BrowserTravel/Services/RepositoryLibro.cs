// <copyright file="RepositoryLibro.cs" company="Alexander Romero">
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

    public class RepositoryLibro : IRepositoryLibro
    {
        private readonly ApplicationDBContext dbContext;

        public RepositoryLibro(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<Libro> Create(Libro libro)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(Libro libro)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Exist(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task GetByAutorID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task GetByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Libro>> GetAll()
        {
            return await this.dbContext.Libros.Select(s => s).ToListAsync();
        }

        public Task Update(Libro libro)
        {
            throw new System.NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await this.dbContext.SaveChangesAsync();
        }
    }
}
