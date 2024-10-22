using System.ComponentModel.DataAnnotations;

namespace APIFilmeStudy.DTO.Send;
public class SendUserDto
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public DateOnly DateBirth { get; set; }

    [DataType(DataType.Password)] 
    public string Password { get; set; }
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}

