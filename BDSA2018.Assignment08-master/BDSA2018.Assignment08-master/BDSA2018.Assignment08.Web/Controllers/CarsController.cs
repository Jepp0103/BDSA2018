using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BDSA2018.Assignment08.Models;
using BDSA2018.Assignment08.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BDSA2018.Assignment08.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private ICarRepository _repository;

        public CarsController(ICarRepository repository)
        {
            _repository = repository;
        }

        // GET api/cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> Get()
        {
            return await _repository.Read().ToListAsync();
        }

        // GET api/cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> Get(int id)
        {
            var car = await _repository.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // GET api/cars/5
        [HttpGet("{id}/image")]
        public async Task<ActionResult<byte[]>> GetImage(int id)
        {
            var image = await _repository.FindImageAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return File(image, "image/jpeg");
        }

        // POST api/cars
        [HttpPost]
        public async Task<ActionResult<CarDTO>> Post([FromBody] CarCreateDTO car)
        {
            var created = await _repository.CreateAsync(car);

            return CreatedAtAction(nameof(Get), new { created.Id }, created);
        }

        // PUT api/cars/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CarUpdateDTO car)
        {
            var updated = await _repository.UpdateAsync(car);

            if (updated)
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE api/cars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _repository.DeleteAsync(id);

            if (deleted)
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
