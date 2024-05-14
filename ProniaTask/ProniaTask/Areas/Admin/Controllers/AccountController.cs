using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProniaTask.Core.Models;
using ProniaTask.ViewModels;

namespace ProniaTask.Areas.Admin.Controllers;
[Area("Admin")]
public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager = null)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    //public async Task<IActionResult> CreateAdmin()
    //{
    //    AppUser admin = new AppUser()
    //    {
    //        FullName = "Fuad Memmedov",
    //        UserName = "Admin"


    //    };
    //    await _userManager.CreateAsync(admin, "Admin123@");
    //    await _userManager.AddToRoleAsync(admin, "SuperAdmin");

    //    return Ok("Admin yarandi");
    //}

    //public async Task<IActionResult> CreateRole()
    //{
    //    IdentityRole ıdentityRole1 = new IdentityRole("SuperAdmin");
    //    IdentityRole ıdentityRole2 = new IdentityRole("Admin");
    //    IdentityRole ıdentityRole3 = new IdentityRole("Member");




    //    await _roleManager.CreateAsync(ıdentityRole1);
    //    await _roleManager.CreateAsync(ıdentityRole2);
    //    await _roleManager.CreateAsync(ıdentityRole3);

    //    return Ok("Rollar yarandi");
    //}
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(AdminLoginVm adminLoginVm)
    {
        if (!ModelState.IsValid)
            return View();

        AppUser user = await _userManager.FindByNameAsync(adminLoginVm.UserName);
        if(user == null)
        {
            ModelState.AddModelError("", "Username or password is not valid");
            return View();
        }
       var result = await _signInManager.PasswordSignInAsync(user, adminLoginVm.Password, adminLoginVm.IsPersistent,false);
        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Username or password is not valid");
            return View();
        }


        return RedirectToAction("index", "dashboard");
    }

    public async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}
