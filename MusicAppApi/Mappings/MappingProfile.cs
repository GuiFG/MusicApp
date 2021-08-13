using MusicAppApi.Model;
using MusicAppApi.DTOs;
using AutoMapper;

namespace MusicAppApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap();
            
            CreateMap<Music, MusicDTO>()
                .ReverseMap();
        }
    }

}