using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using DTT_Test.Helpers;
using DTT_Test.Models;
using DTT_Test.Models.Users;
using DTT_Test.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace DTT_Test.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(IUserRepository userRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("/api/auth")]
        public IActionResult Authenticate([FromBody] AuthenticateModel model)
        {
            // Authenticates the user
            var user = _userRepository.Authenticate(model.Username, model.Password);

            if (user == null)
                // return error message if there was no user
                return BadRequest(new { message = "Username or password is incorrect" });

            // Creating the JWT token handler
            var tokenHandler = new JwtSecurityTokenHandler();
            // Encodes the string
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            // Settings for the token
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                // Setting the expiry date or time of the token
                Expires = DateTime.UtcNow.AddMinutes(60),
                // Signing the token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            // Creating the token
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Username = user.Username,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("/api/register")]
        public IActionResult Register([FromBody] RegisterModel model)
        {
            var user = _mapper.Map<User>(model);

            try
            {
                // Creates the user and stores it in the database
                _userRepository.Create(user, model.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Gets the user from the database
            var user = _userRepository.GetById(id);
            var model = _mapper.Map<UserModel>(user);
            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateModel model)
        {
            var user = _mapper.Map<User>(model);
            user.Id = id;

            try
            {
                // Updates the user and stores it in the database
                _userRepository.Update(user, model.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Delets the user
            _userRepository.Delete(id);
            return Ok();
        }
    }
}
