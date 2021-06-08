using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameEnter.Areas.Identity.Data;

namespace GameEnter.Data
{
    public static class RolesSeed
    {
        public static async Task SeedRolesAsync(UserManager<GameEnterUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.SuperAdmin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.LobbyOwner.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Enums.Roles.BasicUser.ToString()));
        }
    }
}
