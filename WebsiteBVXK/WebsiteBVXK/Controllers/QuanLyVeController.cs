using Microsoft.AspNetCore.Mvc;
using BVXK.Application.Create

using System;
using System.Threading.Tasks;
namespace WebsiteBVXK.Controllers
{
    public class QuanLyVeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
