using BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BusinessLogicLayer;
using DataAccessLayer.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinTossController : ControllerBase
    {
        private readonly ICoinTossService _coinTossService;

        public CoinTossController(ICoinTossService coinTossService)
        {
            _coinTossService = coinTossService;
        }

        [HttpGet("getById/{id}")]
        public async Task<ActionResult<CoinToss>> GetCoinTossById(int id)
        {
            var coinToss = await _coinTossService.GetCoinTossByIdAsync(id);
            if (coinToss == null)
            {
                return NotFound();
            }
            return Ok(coinToss);
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<List<CoinToss>>> GetAllCoinTossData()
        {
            var coinTosses = await _coinTossService.GetAllCoinTossDataAsync();
            return Ok(coinTosses);
        }

        [HttpPost("addCoinToss")]
        public async Task<ActionResult<CoinToss>> AddCoinTossData(CoinToss coinToss)
        {
            var createdCoinToss = await _coinTossService.AddCoinTossDataAsync(coinToss);
            return CreatedAtAction(nameof(GetCoinTossById), new { id = createdCoinToss.Id }, createdCoinToss);
        }

        [HttpPut("updateById/{id}")]
        public async Task<ActionResult<CoinToss>> UpdateCoinTossData(int id, CoinToss coinToss)
        {
            var updatedCoinToss = await _coinTossService.UpdateCoinTossDataAsync(id, coinToss);
            if (updatedCoinToss == null)
            {
                return NotFound();
            }
            return Ok(updatedCoinToss);
        }

        [HttpDelete("deleteById/{id}")]
        public async Task<IActionResult> DeleteCoinTossDataById(int id)
        {
            await _coinTossService.DeleteCoinTossDataByIdAsync(id);
            return NoContent();
        }
    }
}
