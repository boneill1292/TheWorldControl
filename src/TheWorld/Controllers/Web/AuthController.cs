using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheWorld.Models;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{

  public class AuthController : Controller
  {
    private SignInManager<WorldUser> _signInManager;

    public AuthController(SignInManager<WorldUser> signInManager)
    {
      _signInManager = signInManager;
    }


    public IActionResult Login()
    {
      if (User.Identity.IsAuthenticated)
      {
        return RedirectToAction("Trips", "App");
      }

      return View();
    }

    [HttpPost]
    public ActionResult Login(LoginViewModel vm)
    {
      if (ModelState.IsValid)
      {
        //Asp.net Identity 53m 26s - Implement Login and Logout. 3:15 mins
        var signInResult =  _signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, false);

        if (signInResult.IsCompleted)
        {
          return RedirectToAction("Trips","App");
        }
        else
        {
          ModelState.AddModelError("", "UserName or Password Incorrect");
        }

      }

      return View();
    }






  }
}
