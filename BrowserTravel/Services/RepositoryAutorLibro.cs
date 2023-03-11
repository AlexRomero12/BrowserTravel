// <copyright file="RepositoryAutorLibro.cs" company="Alexander Romero">
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

    public class RepositoryAutorLibro : IRepositoryAutorLibro
    {
        private readonly ApplicationDBContext dbContext;

        public RepositoryAutorLibro(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task Create(Autor_has_libro autorLibro)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(Autor_has_libro autorLibro)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Autor_has_libro>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Autor_has_libro> GetById(int autorId, int libroId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Autor_has_libro>> GetByLibro(int libroId)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Autor_has_libro autorLibro)
        {
            throw new System.NotImplementedException();
        }
    }
}
