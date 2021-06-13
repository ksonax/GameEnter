using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GameEnter.Models;

namespace GameEnter.Data
{
    public class DataContext : DbContext
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
    }
}
