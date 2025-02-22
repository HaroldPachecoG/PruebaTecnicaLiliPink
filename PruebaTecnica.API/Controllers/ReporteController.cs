using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Data;

namespace PruebaTecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReporteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("reporte")]
        public IActionResult ObtenerReporte()
        {
            var totalEncontrados = _context.Busquedas.Count(b => b.Resultado);
            var totalNoEncontrados = _context.Busquedas.Count(b => !b.Resultado);

            double relacion = (totalEncontrados + totalNoEncontrados) > 0
                ? totalEncontrados / (double)(totalEncontrados + totalNoEncontrados)
                : 0;

            return Ok(new
            {
                cuenta_contieneNombre = totalEncontrados,
                cuenta_noContieneNombre = totalNoEncontrados,
                relacion
            });
        }
    }
}
