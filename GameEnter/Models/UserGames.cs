using GameEnter.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameEnter.Models
{
    public class UserGames
    {
        public int Id { get; set; }
        public GameEnterUser User { get; set; }

        public List<Game> UserLibrary { get; set; }
    }
}
