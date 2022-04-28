using BVXK.Application.CreateThongKe;
using BVXK.Application.GetThongKeBetween;
using BVXK.Application.GetThongKes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebsiteBVXK.Controllers
{
    [Route("[controller]")]
    public class ThongKeController : Controller
    {
        [HttpGet("")]
        public IActionResult GetThongKes([FromServices] GetThongKes getThongKes)
            => Ok(getThongKes.Do());
        [HttpGet("{from}/{to}")]
        public IActionResult GetThongKeBetween(string from, string to, [FromServices] GetThongKeBetween getThongKeBetween)
            => Ok(getThongKeBetween.Do(from, to));
        [HttpPost]
        public async Task<IActionResult> CreateThongKe(
            [FromBody] CreateThongKe.ThongKeViewModel request,
            [FromServices] CreateThongKe createThongKe)
            => Ok(await createThongKe.Do(request));
    }
}
