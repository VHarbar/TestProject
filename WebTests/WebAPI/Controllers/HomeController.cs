using AutoMapper;
using BusinessLogicLayer.Services;
using DataAccessLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Diagnostics;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IUserService userService,IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost]

        public async Task<ActionResult<int>> Create([FromBody] UserDto user)
        {
            var newUser = await _userService.AddUser(user);
            return Ok(newUser);
        }

    }
}