using System;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Data;
using PruebaTecnica.Logica.Models;
using PruebaTecnica.Logica.Services;

namespace PruebaTecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimerPuntoController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PrimerPuntoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("contieneNombre")]
        public IActionResult ContieneNombre([FromBody] PeticionModel peticion)
        {
            bool resultado = EjercicioService.ContieneNombre(peticion.Info, peticion.Nombre);

            _context.Busquedas.Add(new Busqueda { NombreBuscado = peticion.Nombre, Resultado = resultado });
            _context.SaveChanges();

            return Ok(new { resultado });
        }

        public class PeticionModel
        {
            public string[] Info { get; set; }
            public string Nombre { get; set; }
        }
    }
}
