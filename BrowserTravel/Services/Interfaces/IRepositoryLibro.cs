// <copyright file="IRepositoryLibro.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BrowserTravel.Models;

    /// <summary>
    /// Interface Repository Libro.
    /// </summary>
    public interface IRepositoryLibro
    {
        /// <summary>
        /// Get all Libros.
        /// </summary>
        /// <returns>Libro list.</returns>
        Task<List<Libro>> GetAllAsync();

        /// <summary>
        /// Get libro by ID.
        /// </summary>
        /// <param name="id">Libro id.</param>
        /// <returns>Libro entity.</returns>
        Task<Libro> GetByIdAsync(int id);

        /// <summary>
        /// Add libro in BD.
        /// </summary>
        /// <param name="libro">Libro entity.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task AddAsync(Libro libro);

        /// <summary>
        /// Update libro in BD.
        /// </summary>
        /// <param name="libro">Libro entity.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task UpdateAsync(Libro libro);

        /// <summary>
        /// Delete libro in BD.
        /// </summary>
        /// <param name="libro">Libro entity.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        Task DeleteAsync(Libro libro);
    }
}
