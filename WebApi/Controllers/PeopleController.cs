using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Models;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class PeopleController : ControllerBase
   {
      public DataAccess DataAccess { get; }

      public PeopleController(DataAccess dataAccess)
      {
         DataAccess = dataAccess;
      }

      [HttpGet]
      public IAsyncEnumerable<PeopleDto> Get()
      {
         var model = DataAccess.People
            .ProjectToType<PeopleDto>()
            .AsNoTracking()
            .AsAsyncEnumerable();
         return model;
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<PeopleDto?>> Get(int id)
      {
         return await DataAccess.People.AsNoTracking()
            .Where(c => c.Id == id)
            .ProjectToType<PeopleDto>()
            .FirstOrDefaultAsync();
      }

      [HttpPost]
      public async Task<IActionResult> Post([FromBody] PeopleDto value)
      {
         People model = value.Adapt<People>();
         model.CreatedAt = DateTime.Now;
         await DataAccess.People.AddAsync(model);
         await DataAccess.SaveChangesAsync();
         return CreatedAtAction(nameof(Get), model.Adapt<PeopleDto>());
      }

      [HttpPut("{id}")]
      public async Task<IActionResult> Put(int id, [FromBody] PeopleDto value)
      {
         People? model = await DataAccess.People.FindAsync(id);
         if (model != null)
         {
            model.Name = value.Name;
            await DataAccess.SaveChangesAsync();
            return NoContent();
         }
         return BadRequest();
      }

      // DELETE api/<PeopleController>/5
      [HttpDelete("{id}")]
      public void Delete(int id)
      {
      }
   }
}
