namespace FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex.Dto;

public record class CarrierCode
{
    public string sirena {get;set;} = String.Empty;

    public string iata {get;set;} = String.Empty;

    public string icao {get;set;} = String.Empty;
}
