using FlightsBot.Domain.Entities;
using FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex.Clients;
using FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex.Dto;
using FlightsBot.Infrustructure.Interfaces.DataAccess.Repositories;
using NodaTime;

namespace FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex;

public class YandexFlightProviderRepository : IFlightProviderRepository
{
    private readonly YandexClient YandexClient;

    public YandexFlightProviderRepository(YandexClient yandexClient)
    {
        YandexClient = yandexClient;
    }

    public async Task<List<Flight>> GetFlightsAsync(Airport airportFrom, Airport airportTo, Instant flightDate)
    {
        List<Flight> Flights = [];

        var ProviderFlights = await YandexClient.GetFlightsAsync();

        foreach (Segment segment in ProviderFlights?.segments ?? [])
        {
            Flight flight = new Flight();
        }

        return Flights;
    }
}
