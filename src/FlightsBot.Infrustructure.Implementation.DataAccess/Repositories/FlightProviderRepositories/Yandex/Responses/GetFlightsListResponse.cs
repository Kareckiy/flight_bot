using FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex.Dto;

namespace FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex.Responses;

public class GetFlightsListResponse
{
    public List<Segment>? segments { get; set;} 
}
