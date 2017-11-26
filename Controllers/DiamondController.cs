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
                //alternatively could parse from .csv
                _context.Diamonds.Add(new Diamond { Shape="Round", Size=1.02,
                            Color="D", Clarity="IF",Price=15000, ListPrice=18000 });
                _context.Diamonds.Add(new Diamond { Shape="Pear", Size=1.5,
                            Color="E", Clarity="WS1",Price=20000, ListPrice=21000 });
                _context.Diamonds.Add(new Diamond { Shape="Emerald", Size=.95,
                            Color="G", Clarity="WS2",Price=12000, ListPrice=10000 });        
                _context.Diamonds.Add(new Diamond { Shape="Round", Size=2.15,
                            Color="F", Clarity="I2",Price=50000, ListPrice=55000 });
                _context.Diamonds.Add(new Diamond { Shape="Emerald", Size=.5,
                            Color="D", Clarity="IF",Price=2000, ListPrice=3000 });
                _context.Diamonds.Add(new Diamond { Shape="Pear", Size=1.2,
                            Color="G", Clarity="I1",Price=15000, ListPrice=12000 });           
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
        {
            //only client for now is specified to be our front end. if we add more may need further verification
            if (diamond == null)
            {
                return BadRequest();
            }
            _context.Diamonds.Add(diamond);
            _context.SaveChanges();

            return Ok();
        }
    }
}