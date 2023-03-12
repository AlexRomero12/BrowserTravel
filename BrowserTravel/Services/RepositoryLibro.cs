using System.Collections.Generic;
using System.Threading.Tasks;
using BrowserTravel;
using BrowserTravel.Models;
using BrowserTravel.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// RepositoryLibro.
/// </summary>
public class RepositoryLibro : IRepositoryLibro
{
    private readonly ApplicationDBContext dBContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="RepositoryLibro"/> class.
    /// </summary>
    /// <param name="context">ApplicationDBContext</param>
    public RepositoryLibro(ApplicationDBContext context)
    {
        this.dBContext = context;
    }

    /// <inheritdoc/>
    public async Task<List<Libro>> GetAllAsync()
    {
        return await this.dBContext.Libros.Include(i => i.Editorial).ToListAsync();
    }

    /// <inheritdoc/>
    public async Task<Libro> GetByIdAsync(int id)
    {
        return await this.dBContext.Libros.Include(i => i.Editorial).FirstOrDefaultAsync(m => m.ISBN == id);
    }

    /// <inheritdoc/>
    public async Task AddAsync(Libro libro)
    {
        this.dBContext.Add(libro);
        await this.dBContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task UpdateAsync(Libro libro)
    {
        this.dBContext.Update(libro);
        await this.dBContext.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task DeleteAsync(Libro libro)
    {
        this.dBContext.Libros.Remove(libro);
        await this.dBContext.SaveChangesAsync();
    }
}
