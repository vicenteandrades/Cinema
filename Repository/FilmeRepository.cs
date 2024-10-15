using APIFilmeStudy.Context;
using APIFilmeStudy.Model;

namespace APIFilmeStudy.Repository;
public class FilmeRepository : BaseRepository<Filme>
{
    public FilmeRepository(FilmeContext context) : base(context)
    {
    }
}

