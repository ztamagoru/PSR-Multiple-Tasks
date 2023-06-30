using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("cards")]

    public class CardController: ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> ProcessCard([FromBody] string card)
        {
            var randomvalue = CardGen.NextDouble();
            var approved = randomvalue > 0.1;

            await Task.Delay(1000);

            Console.WriteLine($"Card number {card} approved");
            return Ok(new {Card = card, Approved = approved});
        }
    }
}
