using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MagicVilla_VillaAPI.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/VillaAPI")]
    //[ApiController]
    public class VillaAPIController : ControllerBase
    {
        //private readonly ILogger<VillaAPIController> _logger;
        
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<VillaAPIController> _logger;
        public VillaAPIController(ApplicationDbContext db, IMapper mapper, ILogger<VillaAPIController> logger) 
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<VillaDto>>> GetVillas()
        {
            IEnumerable<Villa> villaList = await _db.Villas.ToListAsync();
            _logger.LogInformation("Getting all villas");
            return Ok(_mapper.Map<List<VillaDto>>(villaList));

        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        //[ProducesResponseType(200, Type = typeof(VillaDto)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VillaDto>> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("No villa With Id" + id);
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<VillaDto>(villa));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<VillaDto>> CreateVilla([FromBody]VillaCreateDto createDto)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }*/
            if(await _db.Villas.FirstOrDefaultAsync(u => u.Name.ToLower() == createDto.Name.ToLower()) != null){
                ModelState.AddModelError("CustomError", "Villa already Exists");
                return BadRequest(ModelState);
            }
            if (createDto == null)
            {
                return BadRequest(createDto);
            }

            //if (villaDto.Id > 0)
            //{
            //    return StatusCode(StatusCodes.Status500InternalServerError);
            //}
            Villa model = _mapper.Map<Villa>(createDto);

            //Villa model = new Villa()
            //{
            //    Amenity = createDto.Amenity,
            //    Details = createDto.Details,
            //    ImageUrl = createDto.ImageUrl,
            //    Name = createDto.Name,
            //    Occupancy = createDto.Occupancy,
            //    Rate = createDto.Rate,
            //    Sqft = createDto.Sqft
            //};
            await _db.Villas.AddAsync(model);
            _logger.LogInformation("Villa got created successfully");
            await _db.SaveChangesAsync();
            

            return CreatedAtRoute("GetVilla", new {id = model.Id}, model);
        }

        [HttpDelete("{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }
            var villa = await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            _logger.LogWarning("The villa gets deleted permanently");
            _db.Villas.Remove(villa);
            await _db.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVilla(int id, [FromBody]VillaUpdateDto updateDto )
        {
            if (updateDto == null || id != updateDto.Id) 
            { 
                return BadRequest();
            }
            //var villa = _db.Villas.FirstOrDefault(u=> u.Id == id);
            //villa.Name = villaDto.Name;
            //villa.Sqft = villaDto.Sqft;
            //villa.Occupancy = villaDto.Occupancy;

            Villa model = _mapper.Map<Villa>(updateDto);

            //Villa model = new Villa()
            //{
            //    Amenity = updateDto.Amenity,
            //    Details = updateDto.Details,
            //    Id = updateDto.Id,
            //    ImageUrl = updateDto.ImageUrl,
            //    Name = updateDto.Name,
            //    Occupancy = updateDto.Occupancy,
            //    Rate = updateDto.Rate,
            //    Sqft = updateDto.Sqft
            //};
            _db.Villas.Update(model);
            _logger.LogInformation("The villa gets updated");
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id,[FromBody] JsonPatchDocument<VillaUpdateDto> patchDto)
        {
            if ( patchDto == null || id == 0 )
            {
                return BadRequest();
            }
            
            
            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(u=>u.Id == id);
            
            VillaUpdateDto villaDto = _mapper.Map<VillaUpdateDto>(villa);

            if ( villa == null)
            {
                return BadRequest();
            }
            patchDto.ApplyTo(villaDto, ModelState);

            Villa model = _mapper.Map<Villa>(villaDto);

            _db.Villas.Update(model);
            _logger.LogInformation("The villa gets updated partially");
            await _db.SaveChangesAsync();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return NoContent() ;
        }


    }
}
