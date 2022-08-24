using API.DTOs;
using API.Entities;
using AutoMapper;

namespace API.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<NoteTag, NoteTagsDto>();
        CreateMap<Tag, TagDto>();
            //.ForMember(dest => dest.Caption, opt => opt.MapFrom(src => "qqq"));

        CreateMap<Note, NoteDto>();
            //.ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags));

        // CreateMap<AppUser, MemberDto>()
        //     .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
        //     .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
        // CreateMap<Photo, PhotoDto>();
        // CreateMap<MemberUpdateDto, AppUser>();
        // CreateMap<RegisterDto, AppUser>();
        // CreateMap<Message, MessageDto>()
        //     .ForMember(dest => dest.SenderPhotoUrl, opt => opt.MapFrom(src => src.Sender.Photos.FirstOrDefault(x => x.IsMain).Url))
        //     .ForMember(dest => dest.RecepientPhotoUrl, opt => opt.MapFrom(src => src.Recipient.Photos.FirstOrDefault(x => x.IsMain).Url))
        //     .ForMember(dest => dest.RecepientId, opt => opt.MapFrom(src => src.RecipientId))
        //     .ForMember(dest => dest.RecepientUsername, opt => opt.MapFrom(src => src.RecipientUsername))
        //     ;
        // CreateMap<DateTime, DateTime>().ConvertUsing(d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
    }
}