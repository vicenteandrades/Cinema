using APIFilmeStudy.Context;
using APIFilmeStudy.Model;

namespace APIFilmeStudy.Repository;
public class EnderecoRepository : BaseRepository<Endereco>
{
    public EnderecoRepository(FilmeContext context) : base(context)
    {
    }
}
