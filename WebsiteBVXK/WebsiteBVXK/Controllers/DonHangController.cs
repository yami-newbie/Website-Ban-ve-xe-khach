using BVXK.Application.CreateDonHang;
using BVXK.Application.DeleteDonHang;
using BVXK.Application.GetDonHang;
using BVXK.Application.GetDonHangs;
using BVXK.Application.UpdateDonHang;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebsiteBVXK.Controllers
{
    [Route("[controller]")]
    public class DonHangController : Controller
    {
        [HttpGet("")]
        public IActionResult GetDonHangs([FromServices] GetDonHangs getDonHangs) =>
            Ok(getDonHangs.Do());

        [HttpGet("{id}")]
        public IActionResult GetDonHang(int id,[FromServices] GetDonHang getDonHang) =>
            Ok(getDonHang.Do(id));

        [HttpPut("")]
        public async Task<IActionResult> UpdateDonHang(
            [FromBody] UpdateDonHang.Request request,
            [FromServices] UpdateDonHang updateDonHang)
        {
            try
            {
                return Ok((await updateDonHang.Do(request)));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonHang(int id, [FromServices] DeleteDonHang deleteDonHang)
        {
            try
            {
                return Ok(await deleteDonHang.Do(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateDonHang(
            [FromBody] CreateDonHang.Request request,
            [FromServices] CreateDonHang createDonHang)
        {
            try
            {
                return Ok(await createDonHang.Do(request));
            }
            catch(Exception err) 
            {
                return BadRequest(err.Message);
            }
        }
    }
}
