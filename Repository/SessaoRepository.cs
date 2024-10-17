using APIFilmeStudy.Context;
using APIFilmeStudy.Model;
using Microsoft.EntityFrameworkCore;

namespace APIFilmeStudy.Repository;
public class SessaoRepository : BaseRepository<Sessao>
{
    public SessaoRepository(FilmeContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Sessao>> GetAsyncComplete()
    {
        return await _context.Sessao.Include(x => x.Cinema).Include(x => x.Filme).ToListAsync();
    }
}

