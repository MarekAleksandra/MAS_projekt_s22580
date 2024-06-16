using MAS_projekt_s22580.Models.Guitars;
using MAS_projekt_s22580.Services;
using MAS_projekt_s22580.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace dfwrf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GuitarController : ControllerBase
    {
        private readonly IGuitarService _guitarService;
        public GuitarController(IGuitarService guitarService)
        {
            _guitarService = guitarService;
        }

        // <summary>
        /// Retrieves all guitar exemplars.
        /// </summary>
        /// <returns>A list of guitar exemplars.</returns>
        [HttpGet("exemplars")]
        public async Task<IActionResult> GetExemplars()
        {
            var guitars = await _guitarService.GetExemplars();
            return Ok(guitars);
        }

        /// <summary>
        /// Retrieves all acoustic guitars.
        /// </summary>
        /// <returns>A list of acoustic guitars.</returns>
        [HttpGet("acoustic")]
        public async Task<IActionResult> GetAcoustic()
        {
            var guitars = await _guitarService.GetAcousticGuitars();
            return Ok(guitars);
        }


        /// <summary>
        /// Retrieves all electric guitars.
        /// </summary>
        /// <returns>A list of electric guitars.</returns>
        [HttpGet("electric")]
        public async Task<IActionResult> GetElectric()
        {
            var guitars = await _guitarService.GetElectricGuitars();
            return Ok(guitars);
        }

        /// <summary>
        /// Retrieves all bass guitars.
        /// </summary>
        /// <returns>A list of bass guitars.</returns>
        [HttpGet("bass")]
        public async Task<IActionResult> GetBass()
        {
            var guitars = await _guitarService.GetBassGuitars();
            return Ok(guitars);
        }

        /// <summary>
        /// Retrieves all types of guitars.
        /// </summary>
        /// <returns>A list of all guitar types.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var guitars = await _guitarService.GetAllGuitars();
            return Ok(guitars);
        }

        /// <summary>
        /// Adds a new guitar exemplar.
        /// </summary>
        /// <param name="newGuitarExemplar">The details of the new guitar exemplar to add.</param>
        /// <returns>A response indicating the result of the operation.</returns>
        [HttpPost("addexemplar")]
        public async Task<IActionResult> AddGuitarExemplar([FromQuery] GuitarExemplarPOST newGuitarExemplar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _guitarService.AddGuitarExemplar(newGuitarExemplar);

            return Created("", "");
        }

        /// <summary>
        /// Adds a new electric guitar.
        /// </summary>
        /// <param name="newGuitar">The details of the new electric guitar to add.</param>
        /// <returns>A response indicating the result of the operation.</returns>
        [HttpPost("addelectric")]
        public async Task<IActionResult> AddGuitarType([FromQuery] GuitarTypeElectricPOST newGuitar)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _guitarService.AddElectricGuitar(newGuitar);

            return Created("", "");
        }
    }
}