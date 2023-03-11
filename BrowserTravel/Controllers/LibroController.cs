// <copyright file="LibroController.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Controllers
{
    using System.Threading.Tasks;
    using BrowserTravel.Entities;
    using BrowserTravel.Migrations;
    using BrowserTravel.Models;
    using BrowserTravel.Services;
    using BrowserTravel.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Libro Controller.
    /// </summary>
    public class LibroController : Controller
    {
        private readonly IRepositoryLibro repositoryLibro;
        private readonly IRepositoryEditorial repositoryEditorial;
        private readonly IRepositoryAutor repositoryAutor;
        private readonly IRepositoryAutorLibro repositoryAutorLibro;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibroController"/> class.
        /// </summary>
        /// <param name="repositoryLibro">repository Libro.</param>
        public LibroController(IRepositoryLibro repositoryLibro, IRepositoryEditorial repositoryEditorial, IRepositoryAutor repositoryAutor, IRepositoryAutorLibro repositoryAutorLibro)
        {
            this.repositoryLibro = repositoryLibro;
            this.repositoryEditorial = repositoryEditorial;
            this.repositoryAutor = repositoryAutor;
            this.repositoryAutorLibro = repositoryAutorLibro;
        }

        /// <summary>
        /// Reder Index View.
        /// </summary>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> Index()
        {
            var libros = await this.repositoryLibro.GetAll();
            return this.View(libros);
        }

        /// <summary>
        /// Reder create view.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Create()
        {
            this.ViewBag.Editoriales = await this.repositoryEditorial.GetAll();
            this.ViewBag.Autores = await this.repositoryAutor.GetAll();
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ISBN,Editorial,Titulo,Sinopsis,N_paginas,AutoresLibros")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                repositoryLibro.Create(libro);
                return RedirectToAction(nameof(Index));
            }

            this.ViewBag.Editoriales = await this.repositoryEditorial.GetAll();
            this.ViewBag.Autores = await this.repositoryAutor.GetAll();
            return this.View();
        }

    }
}
