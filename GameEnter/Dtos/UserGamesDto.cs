using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameEnter.Dtos
{
    public class UserGamesDto
    {
        public string UserId { get; set; }

        public List<GameDto> UserLibrary { get; set; }
    }
}
