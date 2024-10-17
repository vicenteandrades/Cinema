using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APIFilmeStudy.Model;
public class Endereco
{
    [Key]
    public int EnderecoId { get; set; }
    [Required]
    public string? Logradouro { get; set; }
    public int Numero { get; set; }
    [JsonIgnore]
    public virtual Cinema? Cinema { get; set; }
}

