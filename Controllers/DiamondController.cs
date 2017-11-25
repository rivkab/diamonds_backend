using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DiamondsApi.Models;
using System.Linq;

namespace DiamondsApi.Controllers
{
    [Route("api/[controller]")]
    public class DiamondController : Controller
    {
        private readonly DiamondContext _context;

        public DiamondController(DiamondContext context)
        {
            _context = context;

            if (_context.Diamonds.Count() == 0)
            {
                _context.Diamonds.Add(new Diamond { Shape = "Item1" });//TODO add initial data instead
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public IEnumerable<Diamond> GetAll()
        {
            return _context.Diamonds.ToList();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Diamond diamond)
        {//TODO add authentication
            if (diamond == null) //TODO check for legality
            {
                return BadRequest();
            }

            _context.Diamonds.Add(diamond);
            _context.SaveChanges();

            return Ok();
        }
    }
}