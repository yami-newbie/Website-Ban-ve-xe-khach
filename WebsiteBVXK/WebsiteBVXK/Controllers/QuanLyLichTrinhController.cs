using BVXK.Application.CreateLichTrinh;
using BVXK.Application.DeleteLichTrinh;
using BVXK.Application.GetLichTrinh;
using BVXK.Application.GetLichTrinhs;
using BVXK.Application.UpdateLichTrinh;
using BVXK.Application.FindLichTrinh;
using BVXK.Application.FindXe;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebsiteBVXK.Controllers
{
    [Route("[controller]")]
    public class QuanLyLichTrinhController : Controller
    {
        [HttpGet("")]
        public IActionResult GetLichTrinhs([FromServices] GetLichTrinhs getLichTrinhs) =>
            Ok(getLichTrinhs.Do());
        [HttpGet("{id}")]
        public IActionResult GetLichTrinh(int id, [FromServices] GetLichTrinh getLichTrinh) =>
            Ok(getLichTrinh.Do(id));
        [HttpGet("{seat}")]
        public IActionResult FindXe(int seat, [FromServices] FindXe findXe) =>
            Ok(findXe.Do(seat));
        
        [HttpPut("")]
        public async Task<IActionResult> UpdateLichTrinh(
            [FromBody] UpdateLichTrinh.Request request,
            [FromServices] UpdateLichTrinh updateLichTrinh)
        {
            try
            {
                return Ok((await updateLichTrinh.Do(request)));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLichTrinh(int id, [FromServices] DeleteLichTrinh deleteLichTrinh)
        {
            try
            {
                return Ok(await deleteLichTrinh.Do(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateLichTrinh(
            [FromBody] CreateLichTrinh.Request request,
            [FromServices] CreateLichTrinh createLichTrinh)
        {
            try
            {
                return Ok(await createLichTrinh.Do(request));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
