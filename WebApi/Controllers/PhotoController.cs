using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace WebApi.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class PhotoController : ControllerBase
   {
      [HttpPost]
      public void Post([FromForm] Photo value)
      {
         IFormFile? archive = value.Archive;
      }
   }
}
