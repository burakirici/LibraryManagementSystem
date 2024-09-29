using LibraryManagementSystem.Models;
using LibraryManagementSystem.Models.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace LibraryManagementSystem.Controllers
{
    public class AuthController : Controller
    {

        private static List<User> _users = new List<User>()
        {
            new User {Id = 1, Email = "burakzeynep@gmail.com", FirstName = "Zeynep", LastName = "Kırıcı", Password="1234", JoinDate = DateTime.Now, PhoneNumber="5555"},
            new User {Id = 2, Email = "emrecancokterkan@gmail.com", FirstName = "Emre Can", LastName = "Terkan", Password="123457", JoinDate = DateTime.Now, PhoneNumber="55556"},
            new User {Id = 3, Email = "burakirici@gmail.com", FirstName = "Burak", LastName = "Kırıcı", Password="123456", JoinDate = DateTime.Now, PhoneNumber="55556"}
        };

        private readonly IDataProtector _dataProtector;


        public AuthController(IDataProtectionProvider dataProtector)
        {
            _dataProtector = dataProtector.CreateProtector("security");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]

        public IActionResult SignUp(SignUpViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var user = _users.FirstOrDefault(x => x.Email.ToLower() == formData.Email.ToLower());

            if (user is not null)
            {
                ViewBag.Error = "User Already Exists";
                return View(formData);
            }

            var userNew = new User()
            {
                Id = _users.Max(x => x.Id) + 1,
                FirstName = formData.FirstName,
                LastName = formData.LastName,
                Password = _dataProtector.Protect(formData.Password),
                JoinDate = DateTime.Now,
                PhoneNumber = formData.PhoneNumber,
                Email = formData.Email

            };
            _users.Add(userNew);
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel formData)
        {
            if (!ModelState.IsValid)
            {
                return View(formData);
            }
            var user = _users.FirstOrDefault(x => x.Email.ToLower() == formData.Email.ToLower());

            if (user is null)
            {
                ViewBag.Error = "Username or Password is incorrect.";
                return View(formData);
            }
            var rawPassword = _dataProtector.Unprotect(user.Password);
            if (rawPassword == formData.Password)
            {

                var claims = new List<Claim>();
                claims.Add(new Claim("email", user.Email));
                claims.Add(new Claim("id", user.Id.ToString()));



                var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true, // Refreshable login.
                    ExpiresUtc = new DateTimeOffset(DateTime.Now.AddHours(1)) // Login for 1 hours.
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), authProperties);
                
            }
            else
            {
                ViewBag.Error = "Username or password is incorrect";
                return View(formData);
            }
            return RedirectToAction("Index", "Home");


        }
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
