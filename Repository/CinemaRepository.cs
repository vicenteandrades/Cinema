using APIFilmeStudy.Context;
using APIFilmeStudy.Model;

namespace APIFilmeStudy.Repository;
public class CinemaRepository : BaseRepository<Cinema>
{
    public CinemaRepository(FilmeContext context) : base(context)
    {
    }
}

