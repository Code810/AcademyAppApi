using AcademyApp.Application.Dtos.GroupDto;
using AcademyApp.Application.Dtos.StudentDto;
using AcademyApp.Application.Extensions;
using AcademyApp.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace AcademyApp.Application.Profiles
{
    public class MapperProfile : Profile
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public MapperProfile(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            var urlBuilder = new UriBuilder(
                _contextAccessor.HttpContext.Request.Scheme,
                _contextAccessor.HttpContext.Request.Host.Host,
                _contextAccessor.HttpContext.Request.Host.Port.Value
                );
            var url = urlBuilder.Uri.AbsoluteUri;
            //Group
            CreateMap<GroupCreateDto, Group>();

            //Student
            CreateMap<StudentCreateDto, Student>()
                .ForMember(s => s.FileName, map => map.MapFrom(d => d.File.Save(Directory.GetCurrentDirectory(), "uploads/images")));
            CreateMap<Student, StudentReturnDto>().ForMember(d => d.FileName, map => map.MapFrom(s => url + "uploads/images/" + s.FileName));
        }
    }
}
