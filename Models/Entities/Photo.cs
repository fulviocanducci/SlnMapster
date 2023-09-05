using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
   public class Photo
   {
      [Required()]
      [DataType(DataType.Upload)]
      public IFormFile? Archive { get; set; }
   }
}
