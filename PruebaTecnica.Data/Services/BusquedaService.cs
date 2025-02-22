using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PruebaTecnica.Logica.Models;

namespace PruebaTecnica.Data.Services
{
    public class BusquedaService
    {
        private readonly AppDbContext _context;

        public BusquedaService(AppDbContext context)
        {
            _context = context;
        }

        public void GuardarBusqueda(string nombre, bool resultado)
        {
            var busqueda = new Busqueda
            {
                NombreBuscado = nombre,
                Resultado = resultado
            };
            _context.Busquedas.Add(busqueda);
            _context.SaveChanges();
        }

        public int ObtenerConteoExitosas()
        {
            return _context.Busquedas.Count(b => b.Resultado);
        }

        public int ObtenerConteoFallidas()
        {
            return _context.Busquedas.Count(b => !b.Resultado);
        }
    }
}
