using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Models;
using Security.Models.DTOS;
using Security.Services;

namespace Security.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _service;
        public HospitalController(IHospitalService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHospitals()
        {
            IEnumerable<Hospital> items = await _service.GetAll();
            return Ok(items);
        }
        [HttpGet("{id:guid}")]
        [Authorize]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var hospital = await _service.GetOne(id);
            return Ok(hospital);
        }
        [HttpPost]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> CreateHospital([FromBody] CreateHospitalDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var hospital = await _service.CreateHospital(dto);
            return CreatedAtAction(nameof(GetOne), new { id = hospital.Id }, hospital);
        }


        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateHospital([FromBody] UpdateHospitalDto dto)
        {
            if (!ModelState.IsValid)
                return ValidationProblem(ModelState);

            var hospital = await _service.UpdateHospital(dto);

            if (hospital == null)
            {
                return NotFound();
            }

            return Ok(hospital);
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "AdminOnly")]
        public async Task<IActionResult> DeleteHospital(Guid id)
        {
            var deleted = await _service.DeleteHospital(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetAllByTypes()
        {
            var publicTypes = new List<int> { 1, 3 };
            IEnumerable<Hospital> items = await _service.GetAllByTypes(publicTypes);

            return Ok(items);
        }
    }
}