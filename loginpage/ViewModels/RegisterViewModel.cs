using System.ComponentModel.DataAnnotations;
using loginpage.ValidatorAttributes;

namespace loginpage.ViewModels;

public class RegisterViewModel
{
    [Required]
    public string Fullname { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    [Compare(nameof(Password))]
    public string ConfirmedPassword { get; set; }
    
    [Required]
    [Phone]
    public string Phone { get; set; }
    
    [Required]
    [MinimumAge(13)]
    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTimeOffset Birthdate { get; set; }
}