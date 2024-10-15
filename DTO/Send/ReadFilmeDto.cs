using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.DTO;
public class ReadFilmeDto
{
    [Required]
    public string? Titulo { get; set; }
    [Required]
    public string Genero { get; set; }
    [Required]
    public int Duracao { get; set; }
}

