// <copyright file="IRepositoryAutorLibro.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BrowserTravel.Entities;

    public interface IRepositoryAutorLibro
    {
        Task Create(Autor_has_libro autorLibro);

        Task Update(Autor_has_libro autorLibro);

        Task Delete(Autor_has_libro autorLibro);

        Task<Autor_has_libro> GetById(int autorId, int libroId);

        Task<IEnumerable<Autor_has_libro>> GetAll();

        Task<IEnumerable<Autor_has_libro>> GetByLibro(int libroId);
    }
}
