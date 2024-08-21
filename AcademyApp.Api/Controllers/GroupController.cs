using AcademyApp.Application.Dtos.GroupDto;
using AcademyApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcademyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_groupService.GetAll());
        }
        [HttpPost]
        public IActionResult Create(GroupCreateDto groupCreateDto)
        {

            return Ok(_groupService.Create(groupCreateDto));
        }

    }
}
