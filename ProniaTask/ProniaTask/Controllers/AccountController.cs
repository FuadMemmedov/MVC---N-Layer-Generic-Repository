using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProniaTask.Core.Models;
using ProniaTask.ViewModels;

namespace ProniaTask.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(MemberRegisterVm memberRegisterVm)
    {
        if (!ModelState.IsValid)
            return View();

        AppUser user = null;

        user = await _userManager.FindByNameAsync(memberRegisterVm.UserName);
        if(user is not null)
        {
            ModelState.AddModelError("UserName", "UserName already exist!");
            return View();
        }

        user = await _userManager.FindByEmailAsync(memberRegisterVm.Email);
        if (user is not null)
        {
            ModelState.AddModelError("Email", "Email already exist!");
            return View();
        }

        user = new AppUser
        {
            FullName = memberRegisterVm.Name + " " + memberRegisterVm.Surname,
            Email = memberRegisterVm.Email,
            UserName = memberRegisterVm.UserName
        };
        var result = await _userManager.CreateAsync(user, memberRegisterVm.Password);

        if (!result.Succeeded)
        {
            foreach(var err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
                return View();
                 
            }
        }


        await _userManager.AddToRoleAsync(user, "Member");
        return View("Login");
    }

    public IActionResult Login()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(UserLoginVm userLoginVm)
    {
        if (!ModelState.IsValid)
            return View();

        AppUser user = await _userManager.FindByNameAsync(userLoginVm.UserName);
        if (user == null)
        {
            ModelState.AddModelError("", "Username or password is not valid");
            return View();
        }
        var result = await _signInManager.PasswordSignInAsync(user, userLoginVm.Password, userLoginVm.IsPersistent, false);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Username or password is not valid");
            return View();
        }


        return RedirectToAction("index", "Home");
    }
    public async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}
