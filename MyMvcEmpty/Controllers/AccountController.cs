using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace MyMvcEmpty.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        //登陆
        public IActionResult MakeLogin(string ReturnUrl)
        {
            var claims = new List<Claim>(){
                new Claim(ClaimTypes.Name,"Songer"),
                new Claim(ClaimTypes.Role,"admin")
            };
            //必须要加CookieAuthenticationDefaults.AuthenticationScheme，不然无法解析
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            if (string.IsNullOrWhiteSpace(ReturnUrl))
            {
                return RedirectToAction("Index", "admin");
            }
            return Redirect(ReturnUrl);
            //return Ok();
        }

        //登出
        public IActionResult Logout(string returnurl)
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login", "account");
        }
    }
}