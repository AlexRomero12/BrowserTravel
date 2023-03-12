// <copyright file="LibroController.cs" company="Alexander Romero">
// Copyright (c) Alexander Romero. All rights reserved.
// </copyright>

namespace BrowserTravel.Controllers
{
    using System.Threading.Tasks;
    using BrowserTravel.Models;
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

        /// <summary>
        /// Initializes a new instance of the <see cref="LibroController"/> class.
        /// </summary>
        /// <param name="repositoryLibro">repository Libro.</param>
        public LibroController(IRepositoryLibro repositoryLibro, IRepositoryEditorial repositoryEditorial)
        {
            this.repositoryLibro = repositoryLibro;
            this.repositoryEditorial = repositoryEditorial;
        }

        /// <summary>
        /// Reder Index View.
        /// </summary>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task<IActionResult> Index()
        {
            var libros = await this.repositoryLibro.GetAllAsync();
            return this.View(libros);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            ViewData["EditorialId"] = new SelectList(await repositoryEditorial.GetAll(), "Id", "NombreCompleto");
            return View();
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ISBN,Titulo,Sinopsis,N_Paginas,EditorialId")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                await repositoryLibro.AddAsync(libro);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorialId"] = new SelectList(await repositoryEditorial.GetAll(), "Id", "NombreCompleto", libro.EditorialId);
            return View(libro);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await this.repositoryLibro.GetByIdAsync(id.Value);
            if (libro == null)
            {
                return NotFound();
            }
            ViewData["EditorialId"] = new SelectList(await repositoryEditorial.GetAll(), "Id", "NombreCompleto", libro.EditorialId);
            return View(libro);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id"></param>
        /// <param name="libro"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ISBN,Titulo,Sinopsis,N_Paginas,EditorialId")] Libro libro)
        {
            if (id != libro.ISBN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await repositoryLibro.UpdateAsync(libro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LibroExists(libro.ISBN))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EditorialId"] = new SelectList(await repositoryEditorial.GetAll(), "Id", "NombreCompleto", libro.EditorialId);
            return View(libro);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await repositoryLibro.GetByIdAsync(id.Value);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await repositoryLibro.GetByIdAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            await repositoryLibro.DeleteAsync(libro);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await repositoryLibro.GetByIdAsync(id.Value);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<bool> LibroExists(int id)
        {
            var libro = await repositoryLibro.GetByIdAsync(id);
            return libro != null;
        }
    }
}
