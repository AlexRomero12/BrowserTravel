// <copyright file="IRepositoryEditorial.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BrowserTravel.Models;

    public interface IRepositoryEditorial
    {
        Task Create(Editorial editorial);

        Task Update(Editorial editorial);

        Task Delete(Editorial editorial);

        Task<bool> Exists(string nombre, string sede);

        Task<List<Editorial>> GetAll();

        Task<Editorial> GetById(int id);
    }
}
