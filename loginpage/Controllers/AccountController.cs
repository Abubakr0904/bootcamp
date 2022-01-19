using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using loginpage.Entities;
using loginpage.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace loginpage.Controllers;

public class AccountController : Controller
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly ILogger<AccountController> _logger;

    public AccountController(SignInManager<User> signInManager, UserManager<User> userManager, ILogger<AccountController> logger)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _logger = logger;
    }

    public IActionResult Login() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel login)
    {
        var user = new User();
        if(login.Email != null)
        {
            user = await _userManager.FindByEmailAsync(login.Email);
        }

        if(user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);

            if(result.Succeeded)
            {
                return RedirectToAction("Index");
            }
        }

        return RedirectToAction("Index");
    }

    public IActionResult Register() => View();
    

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel register)
    {
        var user = new User()
        {
            FullName = register.Fullname,
            PhoneNumber = register.Phone,
            Email = register.Email,
            Birthdate = register.Birthdate,
            UserName = $"{register.Email.Substring(0, register.Email.IndexOf("@"))}{register.Fullname.Substring(0, 2)}"
        };

        Console.WriteLine($"{user.FullName}\n{user.PhoneNumber}\n{user.Email}\n{user.Birthdate}\n{user.UserName}");
        

        var result = await _userManager.CreateAsync(user, register.Password);
        if(result.Succeeded)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(user, register.Password, false, false);
            if(signInResult.Succeeded)
            {
                _logger.LogInformation("User registred successfully");
                return RedirectToAction("Index");
            }
        }

        _logger.LogCritical("Error! User failed to be registered!");
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public async Task<IActionResult> LogOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index");
    }
}