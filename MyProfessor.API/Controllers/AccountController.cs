/*using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using MyProfessor.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
//using Microsoft.AspNet.Identity.Owin;

namespace MyProfessor.API.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<SystemUsers> _userManager;
        private readonly SignInManager<SystemUsers> _signInManager;
        public AccountController(UserManager<SystemUsers> userManager, SignInManager<SystemUsers> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;

        }

        // GET: /<controller>/
        // GET: /Account/Registration
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Registration()
        {
            return View();
        }


        //
        // POST: /Account/Registration
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var users = new SystemUsers { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(users, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(users, isPersistent: false); //extra third argument- rememberBrowser: false
                    return RedirectToAction("index", "Home");
                }
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }

            }

            return View("Registration");
        }


        
        *//*[AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }*//*


        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }





        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
                var res = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
                *//*switch (res)
                {
                    case SignInResult.Success:
                        return RedirectToAction("index", "Home");
                    case SignInResult.LockedOut:
                        return View("Lockout");
                    case SignInResult.Failed:
                    default:
                        ModelState.AddModelError("", "Invalid login attempt.");
                        return View(model);

                }*//*
                if (res.Succeeded)
                {
                    return RedirectToAction("index", "Home");
                }

                ModelState.AddModelError("", "Invalid Login");


            }

            return View(model);
        }



        //
        // POST: /Account/Logout
        [HttpPost]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("index", "Home");
        }

        //add external logins
    }
}
*/