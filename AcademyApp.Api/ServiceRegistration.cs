using AcademyApp.Application.Dtos.GroupDto;
using AcademyApp.Application.Implementations;
using AcademyApp.Application.Interfaces;
using AcademyApp.Application.Profiles;
using AcademyApp.Data.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AcademyApp.Api
{
    public static class ServiceRegistration
    {
        public static void Register(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers()
               .ConfigureApiBehaviorOptions(opt =>
               {
                   opt.InvalidModelStateResponseFactory = context =>
                   {
                       var errors = context.ModelState.Where(e => e.Value?.Errors.Count > 0)
                       .Select(x => new Dictionary<string, string>()
                       {
            { x.Key, x.Value.Errors.First().ErrorMessage }
                       });
                       return new BadRequestObjectResult(new { message = "", errors });
                   };
               });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<AcademyContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssemblyContaining<GroupCreateDtoValidator>();
            services.AddFluentValidationRulesToSwagger();
            services.AddScoped<IGroupService, GroupService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(opt => opt.AddProfile(new MapperProfile(new HttpContextAccessor())));
        }
    }
}
