using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace DatingApp.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        private readonly DataContext _context;
        public ValuesController (DataContext context) {
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Value>>> Get () {
            // Use an async EF method returning a list of data on another thread
            var values = await _context.Values.ToListAsync ();
            return Ok (values);
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public async Task<ActionResult<Value>> Get (int id) {
            // Returns the found value by primary key or null as default
            var value = await _context.Values.FindAsync (id);
            return Ok (value);
        }

        // POST api/values
        [HttpPost]
        public void Post ([FromBody] string value) { }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public void Put (int id, [FromBody] string value) { }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public void Delete (int id) { }
    }
}