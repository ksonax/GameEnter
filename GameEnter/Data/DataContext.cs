using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameEnter.Models;
using GameEnter.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GameEnter.Data
{
    public class DataContext : IdentityDbContext<GameEnterUser>
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }


        public DbSet<Game> GameModel { get; set; }
        public DbSet<Lobby> LobbyModel { get; set; }
        public DbSet<UserGames> UserGamesModel { get ; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
