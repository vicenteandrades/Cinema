using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.Model;
public class Cinema
{
    [Key]
    public int CinemaId { get; set; }
    [Required]
    public string? Nome { get; set; }
    [Required]
    public int EnderecoId { get; set; }
    public virtual Endereco? Endereco { get; set; }
}

