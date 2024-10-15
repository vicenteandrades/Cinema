using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.DTO.Read;
public class SendFilmeDto
{
    public string? Titulo { get; set; }
    public string? Genero { get; set; }
    public int Duracao { get; set; }
}

