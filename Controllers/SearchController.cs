using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using safari_api.Models;

namespace safari_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SearchController
  {
    [HttpGet]
    public ActionResult<string> SearchAnimal([FromQuery] string species)
    {
      return species;
    }
  }
}