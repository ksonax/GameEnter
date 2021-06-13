using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameEnter.Dtos;
using GameEnter.Models;

namespace GameEnter.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Game, GameDto>();
            CreateMap<GameDto, Game>()
                .ForMember(dest => dest.Id, field => field.Ignore())
                .ForMember(dest => dest.GamePicture, field => field.Ignore());
            CreateMap<LobbyDto, Lobby>()
                .ForMember(dest => dest.Id, field => field.Ignore())
                .ReverseMap();
            CreateMap<UserGamesDto, UserGames>()
                .ForMember(dest => dest.Id, field => field.Ignore())
                .ReverseMap();
        }
    }
}
