using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace loginpage.Entities;

public class User : IdentityUser
{
    public string FullName { get; set; }
    
    public DateTimeOffset Birthdate { get; set; }    
}