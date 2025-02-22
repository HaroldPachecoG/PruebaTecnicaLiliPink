using System;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Data;
using PruebaTecnica.Data.Services;
using PruebaTecnica.Logica.Models;
using PruebaTecnica.Logica.Services;

namespace PruebaTecnica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrimerPuntoController : ControllerBase
    {
        private readonly BusquedaService _busquedaService;
        public PrimerPuntoController(BusquedaService busquedaService)
        {
            _busquedaService = busquedaService;
        }

        [HttpPost("contieneNombre")]
        public IActionResult ContieneNombre([FromBody] Peticion peticion)
        {
            bool resultado = EjercicioService.ContieneNombre(peticion.Info, peticion.Nombre);
            _busquedaService.GuardarBusqueda(peticion.Nombre, resultado);
            return Ok(new { resultado });
        }
    }
}
