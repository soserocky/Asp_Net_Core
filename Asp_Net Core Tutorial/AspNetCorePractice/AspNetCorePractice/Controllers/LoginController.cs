using AspNetCorePractice.Models.DTOs;
using AspNetCorePractice.Models.Entities.IdentityEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCorePractice.Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _rolesManager;
        public LoginController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _rolesManager = roleManager;
        }    
        
        [HttpGet("/")]
        public async Task<ActionResult> Index()
        {
            await _rolesManager.CreateAsync(new ApplicationRole() { 
              Name = "Admin"
            });
            return View();
        }

        [HttpPost("/login")]
        public async Task<ActionResult> Index(RegisterDto registerDto)
        {
            ApplicationUser loggedInUser = new ApplicationUser();
            loggedInUser.Email = registerDto.Email;
            loggedInUser.UserName = registerDto.Email;

            var result = await _userManager.CreateAsync(loggedInUser);

            await _signInManager.SignInAsync(loggedInUser, isPersistent: false);

            return new ContentResult() { Content = result.Succeeded.ToString(), ContentType = "text/html", StatusCode = 200 };
        }
    }
}
