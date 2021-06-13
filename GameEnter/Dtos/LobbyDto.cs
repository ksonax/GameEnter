using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameEnter.Dtos
{
    public class LobbyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public GameDto LobbyGame { get; set; }
    }
}
