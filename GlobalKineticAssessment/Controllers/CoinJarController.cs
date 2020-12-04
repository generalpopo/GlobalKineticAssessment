using GlobalKineticAssessment.Models;
using GlobalKineticAssessment.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalKineticAssessment
{
    [ApiController]
    [Route("[controller]")]
    public class CoinJarController : ControllerBase
    {


        private readonly ILogger<CoinJarController> _logger;
        public ICoinJar CoinJar;

        public CoinJarController(ILogger<CoinJarController> logger, ICoinJar coinJar)
        {
            _logger = logger;
            CoinJar = coinJar;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Getting total amount of coins");
            return Ok(new { TotalAmount = $"${CoinJar.GetTotalAmount().ToString("0.00")}" });
        }

        [HttpPost]
        public IActionResult Post([FromBody] CoinDto coin)
        {
            _logger.LogInformation("Adding a coin");
            if (coin.amount < 1)
            {
                return StatusCode(412, "Coin amount must be greater than 0.");
            }
            UsCoin usCoin = new UsCoin(coin.amount);
            CoinJar.AddCoin(usCoin);
            return CreatedAtAction(nameof(Post), usCoin);
        }

        [HttpPut]
        public IActionResult Put()
        {
            _logger.LogInformation("Resetting coin amount");
            CoinJar.Reset();
            return NoContent();
        }
    }
}
