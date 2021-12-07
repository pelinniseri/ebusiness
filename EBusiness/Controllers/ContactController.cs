using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBusiness.Controllers
{
    public class ContactController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            var user = User.Identity.Name;
            ViewBag.d1 = user;
            return View();
        }
    }
}
