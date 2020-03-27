using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeTheHero.Data;
using BeTheHero.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BeTheHero.Controllers
{
    [ApiController]
    [Route("api")]
    public class MainController : ControllerBase
    {
        private readonly MeuDbContext _context;

        public MainController(MeuDbContext context)
        {
            _context = context;
        }

        [HttpPost("ongs")]
        public async Task<ActionResult> CriarOng(Ong ong)
        {
            _context.Ongs.Add(ong);
            await _context.SaveChangesAsync();

            return Ok(ong.Id);
        }

        [HttpGet("ongs")]
        public ActionResult ObterOngs()
        {
            var ongs =  _context.Ongs.ToList();

            return Ok(ongs);
        }

        [HttpPost("sessions/{id:guid}")]
        public ActionResult ObterOngs(Guid id)
        {
            var ongs = _context.Ongs.Where(o => o.Id.Equals(id)).FirstOrDefault();

            return Ok(ongs.Id);
        }

        [HttpGet("profile")]
        public ActionResult ObterTodosCasosDaOng()
        {
            var ong_Id = new Guid(Request.Headers["Autorization"]);

            var incidents = _context.Incidents.Where(i => i.Id.Equals(ong_Id)).ToList();

            return Ok(incidents);
        }

        [HttpPost("incident")]
        public async Task<ActionResult> CriarCaso(Incident incident)
        {
            var id = new Guid(Request.Headers["Autorization"]);
            incident.Ong_id = id;

            _context.Incidents.Add(incident);
            await _context.SaveChangesAsync();

            return Ok(incident.Id);
        }

        [HttpDelete("incident/{id:guid}")]
        public async Task<ActionResult> RemoverCaso(Guid id)
        {
            var ong_Id = new Guid(Request.Headers["Autorization"]);

            var incident = _context.Incidents.Where(i => i.Id.Equals(id) && i.Ong_id.Equals(ong_Id)).FirstOrDefault();
            _context.Incidents.Remove(incident);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("incident")]
        public ActionResult ObterTodosCasos()
        {
            var incidents = _context.Incidents.ToList();

            return Ok(incidents);
        }
    }
}
