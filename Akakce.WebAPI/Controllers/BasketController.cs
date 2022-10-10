using Akakce.Application.Features.Basket;
using Microsoft.AspNetCore.Mvc;

namespace Akakce.WebAPI.Controllers;

public class BasketController : BaseApiController
{
    [HttpPost]
    public async Task<IActionResult> Post(AddItemToBasketCommand command)
    {
        return Ok(await Mediator.Send(command));
    }
}