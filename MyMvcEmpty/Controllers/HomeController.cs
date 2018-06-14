using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace MyMvcEmpty.Controllers
{
    public class HomeController : Controller
    {
        private readonly Class _myClass;
        public HomeController(IOptions<Class> classAccesser)
        {
            _myClass = classAccesser.Value;
        }
        public IActionResult Index()
        {
            ViewBag.TV = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            return View(_myClass);
        }

        public IActionResult Index2()
        {
            return View();
        }

        public IActionResult Index3()
        {
            return View();
        }


        #region 权限
        [Authorize]
        public IActionResult Index4()
        {
            return View();
        }
        #endregion
    }
}