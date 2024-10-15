using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.Model;
public class Cinema
{
    [Key]
    public int CinemaId { get; set; }
    [Required]
    public string? Nome { get; set; }
}

