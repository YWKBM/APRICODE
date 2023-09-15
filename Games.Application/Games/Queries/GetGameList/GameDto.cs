using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Domain;
using Games.Application.Common.Mappings;

namespace Games.Application.Games.Queries.GetGameList
{
    public class GameDto : IMapWith<Game>
    {
        public Guid Id { get; set; }    
        public string Title { get; set; }   
        public string Studio { get; set; }
        public string[] Genres { get; set; } 

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Game, GameDto>()
                .ForMember(gameDto => gameDto.Id,
                opt => opt.MapFrom(game => game.Id))
                .ForMember(gameDto => gameDto.Title,
                opt => opt.MapFrom(game => game.Title))
                .ForMember(gameDto => gameDto.Studio,
                opt => opt.MapFrom(game => game.Studio))
                .ForMember(gameDto => gameDto.Genres,
                opt => opt.MapFrom(game => game.Genres));
        }
    }
}
