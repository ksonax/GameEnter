using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameEnter.Areas.Identity.Data;

namespace GameEnter.Models
{
    public class Lobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Game LobbyGame { get; set; }
        public GameEnterUser Owner { get; set; }
        public List<GameEnterUser> Users { get; set; }
    }
}