using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.Model;
public class Filme
{
    [Key]
    public int FilmeId { get; set; }
    [Required]
    public string? Titulo { get; set;}
    [Required]
    public string Genero { get; set; }
    [Required]
    public int Duracao { get; set; }
}

