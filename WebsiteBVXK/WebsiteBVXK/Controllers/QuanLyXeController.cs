using BVXK.Application.CreateXe;
using BVXK.Application.DeleteXe;
using BVXK.Application.GetXe;
using BVXK.Application.GetXes;
using BVXK.Application.UpdateXe;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace WebsiteBVXK.Controllers
{
    [Route("[controller]")]
    public class QuanLyXeController : Controller
    {
        [HttpGet("xes")]
        public IActionResult GetXes([FromServices] GetXes getXes) =>
            Ok(getXes.Do());

        [HttpGet("xes/{id}")]
        public IActionResult GetXe(int id,[FromServices] GetXe getXe) =>
            Ok(getXe.Do(id));

        [HttpPut("")]
        public async Task<IActionResult> UpdateXe(
            [FromBody] UpdateXe.Request request,
            [FromServices] UpdateXe updateXe)
        {
            try
            {
                return Ok((await updateXe.Do(request)));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteXe(int id, [FromServices] DeleteXe deleteXe)
        {
            try
            {
                return Ok(await deleteXe.Do(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateXe(
            [FromBody] CreateXe.Request request,
            [FromServices] CreateXe createXe)
        {
            try
            {
                return Ok(await createXe.Do(request));
            }
            catch(Exception err) 
            {
                return BadRequest(err.Message);
            }
        }
    }
}
