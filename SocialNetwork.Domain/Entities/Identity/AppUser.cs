using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        //public DateTime RegistrationDate { get; set; }
        //public DateTime LastLoginDate { get; set; }

        // Navigation properties for relationships
        //public Profile Profile { get; set; }
    }
}
