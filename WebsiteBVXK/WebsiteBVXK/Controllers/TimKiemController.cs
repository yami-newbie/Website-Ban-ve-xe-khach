using Microsoft.AspNetCore.Mvc;
using BVXK.Application.FindLichTrinh;
using System;

namespace WebsiteBVXK.Controllers
{
    [Route("[controller]")]
    public class TimKiemController : Controller
    {
        [HttpGet("{start}/{des}/{date}")]
        public IActionResult FindLichTrinh(string start, string des, DateTime date, [FromServices] FindLichTrinh findLichTrinh) =>
            Ok(findLichTrinh.Do(start, des, date));
    }
}
