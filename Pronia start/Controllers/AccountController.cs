using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pronia_start.Models;
using Pronia_start.ViewModels;
using System.Threading.Tasks;

namespace Pronia_start.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> sign;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser>sign)
        {
            this.userManager = userManager;
            this.sign = sign;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser User = new AppUser
            {
                FullName = register.FirstName,
               LastName = register.LastName,
                Email = register.Email,
                UserName = register.UserName
            };
            return RedirectToAction("Index", "Home");
           Microsoft.AspNetCore.Identity.IdentityResult result = await userManager.CreateAsync(User, register.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }

           
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            AppUser user = await userManager.FindByNameAsync(login.Username);

            if (user == null) return View();
            if (login.RememberMe)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await sign.PasswordSignInAsync(user, login.Password, true, true);
                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "You have been dismissed for 5 minutes");
                        return View();
                    }
                    ModelState.AddModelError("", "Username or password is incorrect");
                    return View();
                }
            }
            else
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await sign.PasswordSignInAsync(user, login.Password, false, true);
                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "You have been dismissed for 5 minutes");
                        return View();
                    }
                    ModelState.AddModelError("", "Username or password is incorrect");
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Logout()
        {
            await sign.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Show()
        {
            return Content(User.Identity.IsAuthenticated.ToString());
        }
       
    } 
}
