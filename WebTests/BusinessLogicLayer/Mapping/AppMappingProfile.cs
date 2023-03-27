using AutoMapper;
using DataAccessLayer.DTO;
using DataAccessLayer.Entity;
using DataAcessLayer.Entity;

namespace BusinessLogicLayer.Mapping
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<CrudUserDto, User>()
                .ReverseMap();

            CreateMap<User, UserDto>()
                .ReverseMap();
            CreateMap<Test, TestDto>()
                .ReverseMap();
            CreateMap<Question, QuestionDto>()
                .ReverseMap();
            CreateMap<Answer, AnswerDto>()
                .ReverseMap();
        }
    }
}
