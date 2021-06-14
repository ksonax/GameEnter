using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using GameEnter.Models;
using Microsoft.AspNetCore.Identity;

namespace GameEnter.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the GameEnterUser class
    public class GameEnterUser : IdentityUser
    {
        public byte[] ProfilePicture { get; set; }
    }
}
