using Microsoft.AspNetCore.Mvc;
using RapidMeet.Application.DTOs;
using RapidMeet.Application.Interfaces;

namespace RapidMeet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ParticipantController : ControllerBase
{
    private readonly IParticipantService _participantService;

    public ParticipantController(IParticipantService participantService)
    {
        _participantService = participantService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _participantService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _participantService.GetByIdAsync(id);
        if (result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateParticipantDto dto)
    {
        var result = await _participantService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _participantService.DeleteAsync(id);
        if (!success) return NotFound();
        return NoContent();
    }
}
