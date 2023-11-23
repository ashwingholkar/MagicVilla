using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Dto;
using MagicVilla_VillaAPI.Logger;
using MagicVilla_VillaAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/GetVillas")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        private readonly ILogging _logger;

        private readonly ApplicationDbContext _Db;

        public VillaAPIController(ApplicationDbContext applicationDb, ILogging logger)
        {
            _Db = applicationDb;
            _logger = logger;
        }
        [HttpGet(Name = "GetVillas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.log("getting All Villas!","");
            return Ok(_Db.Villas);

        }
        [HttpGet("{Id:int}", Name = "GetVillaById")]
        //[ProducesResponseType(200,Type = typeof(VillaDTO))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVillaById(int Id)
        {
            if (Id == 0)
            {
                return BadRequest();
            }
            var Villa = _Db.Villas.FirstOrDefault(x => x.Id == Id);

            if (Villa == null)
            {
                return NotFound();
            }
            return Ok(Villa);

        }
        [HttpPost(Name = "CreateVilla")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villa)
        {
            //if(!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            if (_Db.Villas.FirstOrDefault(x => x.Name.ToLower() == villa.Name.ToLower()) != null)
            {
                ModelState.AddModelError("Custom Error", "This Name Already Exists! ");
                return BadRequest(ModelState);
            }
            if (villa == null)
            {
                return BadRequest(villa);
            }
            if (villa.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            Villa Model = new()
            { 
            Name = villa.Name,
            SqFt = villa.SqFt,  
            Occupancy = villa.Occupancy,    
            Amenity = villa.Amenity,      
            Details = villa.Details,
            ImageUrl = villa.ImageUrl,
            Rate = villa.Rate,
            };

            _Db.Villas.Add(Model);
            _Db.SaveChanges();


            return CreatedAtRoute("GetVilla", new { Id = villa.Id }, villa);
        }
        [HttpDelete("{Id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var Villa = _Db.Villas.FirstOrDefault(x => x.Id == id);
            if (Villa == null)
            {
                return NotFound();
            }
            _Db.Villas.Remove(Villa);
            _Db.SaveChanges();

            return NoContent();
        }

        [HttpPut("{Id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int Id, [FromBody] VillaDTO villa)
        {
            Villa Model = new()
            {
                Name = villa.Name,
                SqFt = villa.SqFt,
                Occupancy = villa.Occupancy,
                Amenity = villa.Amenity,
                Details = villa.Details,
                ImageUrl = villa.ImageUrl,
                Rate = villa.Rate,
            };

            _Db.Update(Model);
            _Db.SaveChanges();

            return NoContent();
        }
        [HttpPatch("{Id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int Id, JsonPatchDocument<VillaDTO> patchVillaDto)
        {
            if(Id == 0 || patchVillaDto==null)
            {
                return BadRequest();
            }
            var Villa = _Db.Villas.FirstOrDefault(x => x.Id == Id);
            if (Villa == null)
            {
                return BadRequest();
            }

            VillaDTO VillaDTO = new()
            {
                Name = Villa.Name,
                SqFt = Villa.SqFt,
                Occupancy = Villa.Occupancy,
                Amenity = Villa.Amenity,
                Details = Villa.Details,
                ImageUrl = Villa.ImageUrl,
                Rate = Villa.Rate,
            };

            patchVillaDto.ApplyTo(VillaDTO, ModelState);

            Villa Model = new Villa()
            {
                Name = VillaDTO.Name,
                SqFt = VillaDTO.SqFt,
                Occupancy = VillaDTO.Occupancy,
                Amenity = VillaDTO.Amenity,
                Details = VillaDTO.Details,
                ImageUrl = VillaDTO.ImageUrl,
                Rate = VillaDTO.Rate,
            };
            _Db.Update(Model);
            _Db.SaveChanges();

            return NoContent();
        }
    }

}

