// <copyright file="AutorController.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Controllers
{
    using System.Threading.Tasks;
    using BrowserTravel.Models;
    using BrowserTravel.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Autor controller.
    /// </summary>
    public class AutorController : Controller
    {
        private readonly IRepositoryAutor repositoryAutor;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutorController"/> class.
        /// </summary>
        /// <param name="repositoryAutor">IRepositoryAutor.</param>
        public AutorController(IRepositoryAutor repositoryAutor)
        {
            this.repositoryAutor = repositoryAutor;
        }

        /// <summary>
        /// Reder index view.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Index()
        {
            var autores = await this.repositoryAutor.GetAll();
            return this.View(autores);
        }

        /// <summary>
        /// Reder create view.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Create()
        {
            return this.View();
        }

        /// <summary>
        /// Create autor actions.
        /// </summary>
        /// <param name="autor">Autor entity.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Autor autor)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(autor);
            }

            var exist = await this.repositoryAutor.Exists(autor.Nombre, autor.Apellido);
            if (exist)
            {
                return this.View(autor);
            }

            await this.repositoryAutor.Create(autor);

            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Reder update view.
        /// </summary>
        /// <param name="Id">Autor ID.</param>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Update(int Id)
        {
            var autor = await this.repositoryAutor.GetById(Id);
            if (autor == null)
            {
                return this.RedirectToAction("NotFound", "Home");
            }

            return this.View(autor);
        }

        /// <summary>
        /// Update autor actions.
        /// </summary>
        /// <param name="autor">Autor Entity.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Update(Autor autor)
        {
            var exist = this.repositoryAutor.Exists(autor.Nombre, autor.Apellido);
            if (exist == null)
            {
                return this.RedirectToAction("NotFound", "Home");
            }

            await this.repositoryAutor.Update(autor);
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Reder Delete view.
        /// </summary>
        /// <param name="id">Autor id.</param>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Delete(int id)
        {
            var autor = await this.repositoryAutor.GetById(id);
            if (autor == null)
            {
                return this.RedirectToAction("NotFound", "Home");
            }

            return this.View(autor);
        }

        /// <summary>
        /// Delete autor actions.
        /// </summary>
        /// <param name="autor">Autor entity.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Delete(Autor autor)
        {
            var exist = this.repositoryAutor.Exists(autor.Nombre, autor.Apellido);
            if (exist == null)
            {
                return this.RedirectToAction("NotFound", "Home");
            }

            await this.repositoryAutor.Delete(autor);
            return this.RedirectToAction("Index");
        }


        /// <summary>
        /// Validate Autor Exist.
        /// </summary>
        /// <param name="nombre">Autor nombre.</param>
        /// <param name="apellido">Autor apellido.</param>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> ValidateAutorExist(string nombre, string apellido)
        {
            var autor = await this.repositoryAutor.Exists(nombre, apellido);
            if (autor)
            {
                return this.Json($@"El autor con nombre y apellido {nombre} {apellido} ya existe.");
            }

            return this.Json(true);
        }
    }
}
