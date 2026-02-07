using AutoMapper;
using Inboxly.Dtos.LoginDtos;
using Inboxly.Entities;

namespace Inboxly.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<AppUser, SignUpDto>().ReverseMap();
        }
    }
}
