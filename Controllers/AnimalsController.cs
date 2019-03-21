using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using safari_api.Models;

namespace safari_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AnimalsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAnimals()
    {
      var db = new DatabaseContext();
      var results = db.Animals.OrderBy(animal => animal.Species).ToList();
      return results;
    }

    [HttpGet("{id}")]
    public ActionResult<Animal> GetAnimal(int id)
    {
      var db = new DatabaseContext();
      var animal = db.Animals.FirstOrDefault(a => a.Id == id);
      return animal;
    }

    [HttpPost]
    public ActionResult<Animal> AddAnimal([FromBody] Animal newAnimal)
    {
      var db = new DatabaseContext();
      db.Animals.Add(newAnimal);
      db.SaveChanges();

      return newAnimal;
    }

    [HttpGet("{location}")]
    public ActionResult<IList<Animal>> GetLocation(string location)
    {
      var db = new DatabaseContext();
      var animalsInLocation = db.Animals.
        Where(animal => animal.LocationOfLastSeen == location).ToList();
      return animalsInLocation;
    }

    [HttpPut("{id}")]
    public ActionResult<Animal> UpdateAnimal(int id)
    {
      var db = new DatabaseContext();
      var animal = db.Animals.FirstOrDefault(a => a.Id == id);
      animal.CountOfTimesSeen++;
      db.SaveChanges();
      return animal;
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAnimal(int id)
    {
      var db = new DatabaseContext();
      var animal = db.Animals.FirstOrDefault(a => a.Id == id);
      db.Animals.Remove(animal);
      db.SaveChanges();
      return Ok();
    }
  }
}
