using Microsoft.AspNetCore.Mvc;
using BVXK.Application.Tickets;

using System;
using System.Threading.Tasks;
namespace WebsiteBVXK.Controllers
{
    [Route("[controller]")]
    public class QuanLyVeController : Controller
    {
        [HttpGet("tickets")]
        public IActionResult GetTickets([FromServices] GetTickets getTickets) =>
            Ok(getTickets.Do());
        [HttpGet("tickets/{id}")]
        public IActionResult GetTicket(int id, [FromServices] GetTicket getTicket) =>
            Ok(getTicket.Do(id));
        [HttpPut("")]
        public async Task<IActionResult> UpdateTicket(
            [FromBody] UpdateTicket.Request request,
            [FromServices] UpdateTicket updateTicket)
        {
            try
            {
                return Ok((await updateTicket.Do(request)));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteXe(int id, [FromServices] DeleteTicket deleteTicket)
        {
            try
            {
                return Ok(await deleteTicket.Do(id));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateTicket(
            [FromBody] CreateTicket.Request request,
            [FromServices] CreateTicket createTicket)
        {
            try
            {
                return Ok(await createTicket.Do(request));
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}
