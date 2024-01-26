using FilmHarbor.Core.DTO;
using FilmHarbor.Core.Entities;
using FilmHarbor.Core.RepositoryContracts;
using FilmHarbor.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FilmHarbor.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IJwtService _jwtService;

        public UsersController(IUsersRepository usersRepository,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<Role> roleManager,
            IJwtService jwtService)
        {
            _usersRepository = usersRepository;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtService = jwtService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _usersRepository.GetAllUsers();
        }

        // GET: api/Users/5
        [HttpGet("{userId}")]
        public async Task<ActionResult<User>> GetUser(int userId)
        {
            User? user = await _usersRepository.GetUserByUserId(userId);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // DELETE: api/Users/5
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            User? user = await _usersRepository.GetUserByUserId(userId);
            if (user == null)
            {
                return NotFound();
            }

            await _usersRepository.DeleteUser(user.Id);

            return NoContent();
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Register(RegisterDTO registerDTO)
        {
            //Validation
            if (ModelState.IsValid == false)
            {
                string errorMessage = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                return Problem(errorMessage);
            }

            if (await _userManager.FindByEmailAsync(registerDTO.Email) != null)
            {
                return Problem("Email is already in use.");
            }

            //Create user
            User user = new User()
            {
                PersonName = registerDTO.PersonName,
                UserName = registerDTO.Email,
                Email = registerDTO.Email
            };

            IdentityResult result = await _userManager.CreateAsync(user, registerDTO.Password);

            if (result.Succeeded)
            {
                //Sign-in
                await _signInManager.SignInAsync(user, isPersistent: false);

                AuthenticationResponse authenticationResponse = _jwtService.CreateJwtToken(user);

                return Ok(authenticationResponse);
            }
            else
            {
                string errorMessage = string.Join(" | ", result.Errors.Select(e => e.Description));

                return Problem(errorMessage);
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Login(LoginDTO loginDTO)
        {
            //Validation
            if (ModelState.IsValid == false)
            {
                string errorMessage = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                return Problem(errorMessage);
            }

            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                User? user = await _userManager.FindByEmailAsync(loginDTO.Email);

                if (user == null)
                {
                    return NoContent();
                }

                //Sign-in
                await _signInManager.SignInAsync(user, isPersistent: false);

                AuthenticationResponse authenticationResponse = _jwtService.CreateJwtToken(user);

                return Ok(authenticationResponse);
            }
            else
            {
                return Problem("Invalid email or password.");
            }
        }

        [HttpGet("logout")]
        public async Task<ActionResult<User>> Logout()
        {
            await _signInManager.SignOutAsync();

            return NoContent();
        }
    }
}
