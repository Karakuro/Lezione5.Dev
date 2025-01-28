using Lezione5.Dev.DTO;
using Lezione5.Dev.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lezione5.Dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> _users = new List<User>();
        private readonly ILogger<UserController> _logger;
        private readonly Mapper _mapper = new Mapper();

        public UserController(ILogger<UserController> logger, Mapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_users.ConvertAll(_mapper.MapEntityToDTO));
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var user = _users.SingleOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return BadRequest();
                }
                return Ok(new UserDTO() { Nickname = user.Nickname, Id = user.Id });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Errore critico del server");
            }
        }

        [HttpPost]
        public IActionResult Create(NewUserDTO newUser)
        {
            User user = new User()
            {
                Nickname = newUser.Nickname,
                Password = newUser.Password //VA CRITTOGRAFATA!!!!!
            };
            _users.Add(user);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, NewUserDTO updatedUser)
        {
            try
            {
                var user = _users.SingleOrDefault(u => u.Id == id);
                if (user == null)
                {
                    return BadRequest();
                }
                user.Nickname = updatedUser.Nickname;
                user.Password = updatedUser.Password; //VA CRITTOGRAFATA!!!!!
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Errore critico del server");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                int result = _users.RemoveAll(u => u.Id == id);
                if (result > 1)
                {
                    _logger.LogCritical($"Attenzione, dati sporchi in database con id: {id}");
                    return StatusCode(StatusCodes.Status500InternalServerError,
                    "Errore critico del server");
                }
                return result == 1 ? Ok() : BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Errore critico del server");
            }
        }
    }
}
