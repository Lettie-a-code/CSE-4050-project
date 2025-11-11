using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartAPI.Models;

//AuthController is a separate API layer not a database model 
//AuthControll defines how users send data to register or log in-it does not define the databaseschema
//DTO data transfer object. Represents what the user types into Swagger
namespace ShoppingCartAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // ✅ Register a new user
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                FirstName = model.FirstName,
                MiddleInitial = model.MiddleInitial,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address1 = model.Address1,
                Address2 = model.Address2,
                City = model.City,
                State = model.State,
                PostalCode = model.PostalCode,
                DateRegistered = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { message = "Registration successful" });
        }

        // ✅ Login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
                return Unauthorized(new { message = "Invalid login attempt" });

            return Ok(new { message = "Login successful" });
        }
        // ✅ List all registered users
        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            // Get users from the database
            var users = _userManager.Users
                .OrderBy(u => u.LastName) // 👈 sort first, while we still have the real property
                .Select(u => new
                {
                    u.Id,
                    FullName = $"{u.FirstName} {(string.IsNullOrEmpty(u.MiddleInitial) ? "" : u.MiddleInitial + ". ")}{u.LastName}",
                    u.Email,
                    u.PhoneNumber,
                    u.City,
                    u.State,
                    u.DateRegistered
                })
                .ToList();

            return Ok(users);
        }

    }

    // DTO classes for user input
    public class RegisterRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string? MiddleInitial { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
