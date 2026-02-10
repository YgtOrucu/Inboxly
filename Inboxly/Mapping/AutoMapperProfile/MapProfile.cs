using AutoMapper;
using Inboxly.Dtos.ForEmailSectionDtos;
using Inboxly.Dtos.LoginDtos;
using Inboxly.Dtos.ProfileAreaInTheNavbarDto;
using Inboxly.Entities;

namespace Inboxly.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AppUser, SignUpDto>().ReverseMap();
            CreateMap<AppUser, ProfileAreaSectionDto>().ReverseMap();

            CreateMap<Message, SendNewMessageDtos>().ReverseMap();

            CreateMap<Message, ForInboxDtos>().ForMember(dest => dest.CategoryName,
               opt => opt.MapFrom(src => src.Categories.CategoryName)).ReverseMap();

            CreateMap<Message, ForSendboxDtos>().ForMember(dest => dest.CategoryName,
              opt => opt.MapFrom(src => src.Categories.CategoryName)).ReverseMap();

            CreateMap<Message, EmailDetailsDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.MessageStatusId == 1 ? src.SenderName : src.ReceiverName))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.MessageStatusId == 1 ? src.SenderSurname : src.ReceiverSurname))
                .ForMember(dest => dest.Mail, opt => opt.MapFrom(src => src.MessageStatusId == 1 ? src.SenderMail : src.ReceiverMail));

        }

    }
}
