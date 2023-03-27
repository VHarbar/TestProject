using AutoMapper;
using BusinessLogicLayer.Services;
using DataAccessLayer.DTO;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Attributes;
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
        private readonly ILoginService _loginService;

        public HomeController(ILogger<HomeController> logger, IUserService userService, IMapper mapper, ILoginService loginService)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
            _loginService = loginService;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginDto model)
        {
            var user = _loginService.Authenticate(model.Surname, model.Password);
            if (user == null)
            {
                return null;
            }
            return Ok(user.Token);
        }
        [HttpPost("Surname")]
        public IActionResult GetUserBySurname(string SurName)
        {
            var ID = _userService.GetUserBySurname(SurName);
            return Ok(1);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserWithTests(int id)
        {
            var userDto = await _userService.GetUserWithTests(id);

            if (userDto == null)
            {
                return NotFound();
            }

            return Ok(userDto);
        }
    }
}