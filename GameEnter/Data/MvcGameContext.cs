using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameEnter.Models;

namespace GameEnter.Data
{
    public class MvcGameContext : DbContext
    {
        public MvcGameContext(DbContextOptions<MvcGameContext> options)
            : base(options)
        {
        }

        public DbSet<GameModel> GameModel { get; set; } 
    }
}
