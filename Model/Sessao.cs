using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.Model;
public class Sessao
{
    [Key]
    public int SessaoId { get; set; }
    [Required]
    public int CinemaId { get; set; }
    public Cinema? Cinema { get; set; }
    [Required]
    public int FilmeId { get; set; }
    public Filme? Filme { get; set; }
}
