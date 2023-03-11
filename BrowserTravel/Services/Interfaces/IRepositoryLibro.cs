// <copyright file="IRepositoryLibro.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BrowserTravel.Entities;

    /// <summary>
    /// IRepositoryLibro.
    /// </summary>
    public interface IRepositoryLibro
    {
        /// <summary>
        /// Create libro in BD.
        /// </summary>
        /// <param name="libro">Model libro.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task<Libro> Create(Libro libro);

        Task Update(Libro libro);

        Task Delete(Libro libro);

        Task GetByID(int id);

        Task GetByAutorID(int id);

        Task<bool> Exist(int id);

        Task<List<Libro>> GetAll();
        Task SaveChangesAsync();
    }
}
