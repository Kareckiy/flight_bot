using FlightsBot.Domain.Entities;
using FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex.Clients;
using FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex.Responses;
using FlightsBot.Infrustructure.Interfaces.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace FlightsBot.Controllers;

[Route("api/v1/examples")]
public class ExampleController : ControllerBase
{
    private readonly IDbContext _context;
    
    public ExampleController(IDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<string> Create(CancellationToken cancellationToken)
    {
        var AirplaneEntity = new Airplane("Пулково", 10);

        _context.Airplanes.Add(AirplaneEntity);

        await _context.SaveChangesAsync(cancellationToken);

        return "ok";
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync(YandexClient client, CancellationToken cancellationToken)
    {
        var result = await client.GetFlightsAsync();

        return Ok(result);
    }
}
