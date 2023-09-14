using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Domain;

namespace Games.Application.Games.Queries.GetGameList
{
    public class GameDto
    {
        public Guid Id { get; set; }    
        public string Title { get; set; }   

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Game, GameDto>()
                .ForMember(gameDto => gameDto.Id,
                opt => opt.MapFrom(game => game.Id))
                .ForMember(gameDto => gameDto.Title,
                opt => opt.MapFrom(game => game.Title));
        }
    }
}
