using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DemoLibrary.Data.Models
{
    public class User : IdentityUser
    {
        [MaxLength(40)]
        public string FullName { get; set; }
    }
}
