using APIFilmeStudy.Model;

namespace APIFilmeStudy.DTO.Read;
public class ReadCinemaDto
{
    public string? Nome { get; set; }
    public int EnderecoId { get; set; }
    public ReadEnderecoDto? Endereco { get; set; }
}

