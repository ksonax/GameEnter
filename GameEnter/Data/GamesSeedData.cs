using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GameEnter.Models;


namespace GameEnter.Data
{
    public static class GamesSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DataContext>>()))
            {
                // Look for any movies.
                if (context.GameModel.Any())
                {
                    return;   // DB has been seeded
                }

                context.GameModel.AddRange(
                    new Game
                    {
                        Title = "Counter-Strike Global Offensive",
                        ReleaseDate = DateTime.Parse("2012-08-21"),
                        Genre = "First Person Shooter",
                    },

                    new Game
                    {
                        Title = "League of Legends",
                        ReleaseDate = DateTime.Parse("2009-10-27"),
                        Genre = "MOBA",
                    },

                    new Game
                    {
                        Title = "Tom Clancy's Rainbow Six Siege",
                        ReleaseDate = DateTime.Parse("2015-04-07"),
                        Genre = "Tactical First Person Shooter",
                    },

                    new Game
                    {
                        Title = "Valorant",
                        ReleaseDate = DateTime.Parse("2020-06-02"),
                        Genre = "First Person Shooter",
                    },

                    new Game
                    {
                        Title = "Overwatch",
                        ReleaseDate = DateTime.Parse("2016-05-03"),
                        Genre = "First Person Shooter",
                    },

                    new Game
                    {
                        Title = "Dota 2",
                        ReleaseDate = DateTime.Parse("2013-07-09"),
                        Genre = "MOBA",
                    },

                    new Game
                    {
                        Title = "Fortnite",
                        ReleaseDate = DateTime.Parse("2017-07-21"),
                        Genre = "Battle Royale",
                    },

                    new Game
                    {
                        Title = "Among Us",
                        ReleaseDate = DateTime.Parse("2018-06-15"),
                        Genre = "Social Deduction Multiplayer",
                    },

                    new Game
                    {
                        Title = "Minecraft",
                        ReleaseDate = DateTime.Parse("2011-11-18"),
                        Genre = "Sandbox",
                    },

                    new Game
                    {
                        Title = "Terraria",
                        ReleaseDate = DateTime.Parse("2011-05-16"),
                        Genre = "Sandbox",
                    },

                    new Game
                    {
                        Title = "Grand Theft Auto V",
                        ReleaseDate = DateTime.Parse("2013-09-17"),
                        Genre = "Sandbox",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

