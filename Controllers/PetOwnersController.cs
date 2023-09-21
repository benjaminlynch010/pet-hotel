using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPetOwners() {
            return _context.PetOwners;
        }

        //GET//  /api/bakers/:id
        [HttpGet("{id}")] // How a route param is added in .NET
        public ActionResult<PetOwner> GetById(int id)
        {
            // similar to "SELECT * FROM bakers WHERE id=$1"
            PetOwner PetOwnerWeChoose = _context.PetOwners
                .SingleOrDefault(PetOwner => PetOwner.id == id);

            // We didn't find the baker we were looking for, SEND ERROR!
            if (PetOwnerWeChoose is null)
            {
                return NotFound();
            }
            // We did find the baker we are looking for, let's send that
            // as the response:
            return PetOwnerWeChoose;
        }

        [HttpPost]
        public PetOwner CreatePetOwner(PetOwner newPetOwner)
        {
                // Two step process!
                // 1. We try to create a baker instance,, using the data
                //  that got sent in the POST request.
                _context.Add(newPetOwner);
                // 2. If step 1 works, then we "save" the new baker in our
                //      Bakers table. (INSERT into "Bakers"...)
                _context.SaveChanges();

                return newPetOwner;
        }

        [HttpDelete("{id}")] // How a route param is added in .NET
        public ActionResult<PetOwner> DeleteById(int id)
        {
            // similar to "SELECT * FROM bakers WHERE id=$1"
            PetOwner DeletePetOwner = _context.PetOwners
                .SingleOrDefault(PetOwner => PetOwner.id == id);

            // We didn't find the baker we were looking for, SEND ERROR!
            if (DeletePetOwner is null)
            {
                return NotFound();
            }
            // We did find the baker we are looking for, let's send that
            // as the response:
            return DeletePetOwner;
        }

        
    }
}
