// <copyright file="EditorialController.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Controllers
{
    using System.Threading.Tasks;
    using BrowserTravel.Models;
    using BrowserTravel.Services.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class EditorialController : Controller
    {
        private readonly IRepositoryEditorial repositoryEditorial;

        public EditorialController(IRepositoryEditorial repositoryEditorial)
        {
            this.repositoryEditorial = repositoryEditorial;
        }

        /// <summary>
        /// Reder index view.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public async Task<IActionResult> Index()
        {
            var editoriales = await this.repositoryEditorial.GetAll();
            return this.View(editoriales);
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
        /// Create editorial in BD.
        /// </summary>
        /// <param name="editorial">Autor entity.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Editorial editorial)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(editorial);
            }

            var exist = await this.repositoryEditorial.Exists(editorial.Nombre, editorial.Sede);
            if (exist)
            {
                return this.View(editorial);
            }

            await this.repositoryEditorial.Create(editorial);

            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int id)
        {
            var editorial = await this.repositoryEditorial.GetById(id);
            if (editorial == null)
            {
                return this.RedirectToAction("NotFound", "Home");
            }

            return this.View(editorial);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Editorial editorial)
        {
            var exist = this.repositoryEditorial.Exists(editorial.Nombre, editorial.Sede);
            if (exist == null)
            {
                return this.RedirectToAction("NotFound", "Home");
            }

            await this.repositoryEditorial.Update(editorial);
            return this.RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var autor = await this.repositoryEditorial.GetById(Id);
            if (autor == null)
            {
                return this.RedirectToAction("NotFound", "Home");
            }

            return this.View(autor);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Editorial editorial)
        {
            var exist = this.repositoryEditorial.Exists(editorial.Nombre, editorial.Sede);
            if (exist == null)
            {
                return this.RedirectToAction("NotFound", "Home");
            }

            await this.repositoryEditorial.Delete(editorial);
            return this.RedirectToAction("Index");
        }

        /// <summary>
        /// Validate Autor Exist.
        /// </summary>
        /// <param name="nombre">Autor nombre.</param>
        /// <param name="apellido">Autor apellido.</param>
        /// <returns>IActionResult</returns>
        public async Task<IActionResult> ValidateAutorExist(string nombre, string sede)
        {
            var autor = await this.repositoryEditorial.Exists(nombre, sede);
            if (autor)
            {
                return this.Json($@"La editorial con nombre y sede {nombre} {sede} ya existe.");
            }

            return this.Json(true);
        }
    }
}