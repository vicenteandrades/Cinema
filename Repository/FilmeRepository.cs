using APIFilmeStudy.Context;
using APIFilmeStudy.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFilmeStudy.Repository;
public class FilmeRepository : BaseRepository<Filme>
{
    public FilmeRepository(FilmeContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Filme>> GetWithFilmAsync()
    {
        return await _context.Filme.Include(x => x.Sessoes).ToListAsync();
    }
}

