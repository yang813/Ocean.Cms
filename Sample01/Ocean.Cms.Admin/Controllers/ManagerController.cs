using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ocean.Cms.Admin.Controllers
{
    public class ManagerController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}