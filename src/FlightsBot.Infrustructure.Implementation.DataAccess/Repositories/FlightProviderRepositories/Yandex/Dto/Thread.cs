namespace FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex.Dto;

public record class Thread
{
    public string number {get;set;} = String.Empty;

    public string vehicle {get;set;} = String.Empty;

    public string transport_type {get;set;} = String.Empty;

    public required Carrier carrier {get;set;}
}
