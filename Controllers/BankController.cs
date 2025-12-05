using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BankController : ControllerBase
{
    private readonly IBankRepository _bankRepository;

    public BankController(IBankRepository bankRepository)
    {
        _bankRepository = bankRepository;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllBankDetails()
    {
        var bankDetails = await _bankRepository.GetAllAsync();
        return Ok(bankDetails);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> AddBankDetails([FromBody] BankDetails bankDetails)
    {
        var newBankDetails = await _bankRepository.AddAsync(bankDetails);
        if (newBankDetails == null)
        {
            return BadRequest(new { message = "Employee not found or invalid data." });
        }
        return CreatedAtAction(nameof(GetAllBankDetails), new { id = newBankDetails.Id }, newBankDetails);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateBankDetails([FromBody] BankDetails bankDetails)
    {
        var updatedBankDetails = await _bankRepository.UpdateAsync(bankDetails);
        if (updatedBankDetails == null)
        {
            return NotFound();
        }
        return Ok(updatedBankDetails);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBankDetails(int id)
    {
        var deletedBankDetails = await _bankRepository.NoActiveAsync(id);
        if (deletedBankDetails == null)
        {
            return NotFound();
        }
        return Ok(deletedBankDetails);
    }
}