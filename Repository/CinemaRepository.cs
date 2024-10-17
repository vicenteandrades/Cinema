using APIFilmeStudy.Context;
using APIFilmeStudy.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFilmeStudy.Repository;
public class CinemaRepository : BaseRepository<Cinema>
{
    public CinemaRepository(FilmeContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Cinema>> GetWithAddress()
    {
        return await _context.Cinema.Include(x => x.Endereco).ToListAsync();
    }
}

