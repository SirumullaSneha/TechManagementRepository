using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class PersonalController : ControllerBase
{
    private readonly IPersonalRepository _personalRepository;

    public PersonalController(IPersonalRepository personalRepository)
    {
        _personalRepository = personalRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPersonals()
    {
        var personals = await _personalRepository.GetAllAsync();
        return Ok(personals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPersonalById(int id)
    {
        var personal = await _personalRepository.GetByIdAsync(id);
        if (personal == null)
        {
            return NotFound();
        }
        return Ok(personal);
    }

    [HttpPost]
    public async Task<IActionResult> AddPersonal([FromBody] Personal personal)
    {
        var newPersonal = await _personalRepository.AddAsync(personal);
        return CreatedAtAction(nameof(GetPersonalById), new { id = newPersonal.Id }, newPersonal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePersonal(int id, [FromBody] Personal personal)
    {
        if (id != personal.Id)
        {
            return BadRequest();
        }

        var updatedPersonal = await _personalRepository.UpdateAsync(personal);
        return Ok(updatedPersonal);
    }
}