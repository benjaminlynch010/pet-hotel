using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class PetsController : ControllerBase
  {
    private readonly ApplicationContext _context;
    public PetsController(ApplicationContext context)
    {
      _context = context;
    }

    // This is just a stub for GET / to prevent any weird frontend errors that 
    // occur when the route is missing in this controller
    [HttpGet]
    // .NET fancy way to say a list of pet objects
    public IEnumerable<Pet> GetPets()
    {
      return _context.Pets
      .Include(pet => pet.petOwner);
    }

    [HttpGet("{id}")]

    public ActionResult<Pet> GetById(int id)
    {
      Pet pet = _context.Pets
      .SingleOrDefault(Pet => Pet.id == id);

      if (pet is null)
      {
        return NotFound();
      }

      return pet;
    }

    // POST /api/pets
    [HttpPost]
    public Pet Post(Pet pet)
    {
      _context.Add(pet);
      _context.SaveChanges();

      return pet;
    }

    // PUT /api/pets/:id
    [HttpPut("{id}")]
    public Pet Put(int id, Pet pet)
    {
      pet.id = id;

      _context.Update(pet);

      _context.SaveChanges();

      return pet;
    }

    // DEL /api/pets/:id
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      // Find pet by id
      Pet pet = _context.Pets.Find(id);
      // Hi database remove this pet
      _context.Pets.Remove(pet);

      _context.SaveChanges();
    }

    // [HttpGet]
    // [Route("test")]
    // public IEnumerable<Pet> GetPets() {
    //     PetOwner blaine = new PetOwner{
    //         name = "Blaine"
    //     };

    //     Pet newPet1 = new Pet {
    //         name = "Big Dog",
    //         petOwner = blaine,
    //         color = PetColorType.Black,
    //         breed = PetBreedType.Poodle,
    //     };

    //     Pet newPet2 = new Pet {
    //         name = "Little Dog",
    //         petOwner = blaine,
    //         color = PetColorType.Golden,
    //         breed = PetBreedType.Labrador,
    //     };

    //     return new List<Pet>{ newPet1, newPet2};
    // }
  }
}
