using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lab8.Controllers
{
    [Route("api/fox")]
    [ApiController]
    public class FoxController : ControllerBase
    {
        private readonly IFoxesRepository _repo;

        public FoxController(IFoxesRepository foxesRepository)
        {
            _repo = foxesRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var foxesList = _repo.GetAll();
            if (foxesList.Count() <= 0) return NotFound();
            return Ok(foxesList.OrderByDescending(elem => elem.Loves).ThenBy(elem => elem.Hates));
        }

        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            var fox = _repo.Get(id);
            if (fox == null) return NotFound();
            return Ok(fox);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Fox fox)
        {
            _repo.Add(fox);

            return CreatedAtAction(nameof(Get), new { id = fox.Id }, fox);
        }

        [HttpPut("love/{id}")]
        public IActionResult Love(int id)
        {
            var fox = _repo.Get(id);

            if (fox == null)
                return NotFound();

            fox.Loves++;
            _repo.Update(id, fox);

            return Ok(fox);
        }

        [HttpPut("hate/{id}")]
        public IActionResult Hate(int id)
        {
            var fox = _repo.Get(id);

            if (fox == null)
                return NotFound();

            fox.Hates++;
            _repo.Update(id, fox);

            return Ok(fox);
        }

    }
}