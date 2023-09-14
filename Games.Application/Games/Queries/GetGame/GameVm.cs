using Games.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Domain;
using AutoMapper;

namespace Games.Application.Games.Queries.GetGame
{
    public class GameVm : IMapWith<Game>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Studio { get; set; }
        public string[] Genres { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Game, GameVm>()
                .ForMember(gameVm => gameVm.Id,
                opt => opt.MapFrom(game => game.Id))
                .ForMember(gameVm => gameVm.Title,
                opt => opt.MapFrom(game => game.Title))
                .ForMember(gameVm => gameVm.Studio,
                opt => opt.MapFrom(game => game.Studio))
                .ForMember(gameVm => gameVm.Genres,
                opt => opt.MapFrom(game => game.Genres));
        }
    }
}
