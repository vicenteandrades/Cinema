using Microsoft.AspNetCore.Identity;

namespace APIFilmeStudy.Model;
public class User : IdentityUser
{
	public DateOnly BirthdayDate { get; set; }
	public User() : base()
	{

	}
}

