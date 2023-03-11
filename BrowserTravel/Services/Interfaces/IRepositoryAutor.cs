// <copyright file="IRepositoryAutor.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BrowserTravel.Entities;

    public interface IRepositoryAutor
    {
        Task Create(Autor autor);

        Task Update(Autor autor);

        Task Delete(Autor autor);

        Task<bool> Exists(string name, string lastname);

        Task<List<Autor>> GetAll();

        Task<Autor> GetById(int id);
    }
}
