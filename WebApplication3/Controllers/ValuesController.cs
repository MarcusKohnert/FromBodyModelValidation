using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpPut("{id:int}")]
        public IActionResult Put(
            int id,
            [FromBody]SomeClass value)
        {
            if (this.TryValidateModel(value) == false)
                throw new Exception();
                
            if (this.ModelState.IsValid == false)
                throw new Exception();

            return this.BadRequest(this.ModelState);
        }
    }

    public class SomeClass
    {
        [StringLength(2)]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Name { get; set; }
    }
}
