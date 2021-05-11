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
            using (var context = new GameDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<GameDbContext>>()))
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
                        ReleaseDate = DateTime.Parse("2012-8-21"),
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
                        ReleaseDate = DateTime.Parse("2015-4-7"),
                        Genre = "Tactical First Person Shooter",
                    },

                    new Game
                    {
                        Title = "Valorant",
                        ReleaseDate = DateTime.Parse("2020-6-2"),
                        Genre = "First Person Shooter",
                    },

                    new Game
                    {
                        Title = "Overwatch",
                        ReleaseDate = DateTime.Parse("2016-5-3"),
                        Genre = "First Person Shooter",
                    },

                    new Game
                    {
                        Title = "Dota 2",
                        ReleaseDate = DateTime.Parse("2013-7-9"),
                        Genre = "MOBA",
                    },

                    new Game
                    {
                        Title = "Fortnite",
                        ReleaseDate = DateTime.Parse("2017-7-21"),
                        Genre = "Battle Royale",
                    },

                    new Game
                    {
                        Title = "Among Us",
                        ReleaseDate = DateTime.Parse("2018-6-15"),
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
                        ReleaseDate = DateTime.Parse("2011-5-16"),
                        Genre = "Sandbox",
                    },

                    new Game
                    {
                        Title = "Grand Theft Auto V",
                        ReleaseDate = DateTime.Parse("2013-9-17"),
                        Genre = "Sandbox",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

