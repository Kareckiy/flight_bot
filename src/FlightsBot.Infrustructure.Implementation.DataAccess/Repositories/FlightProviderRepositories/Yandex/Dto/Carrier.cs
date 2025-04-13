namespace FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex.Dto;

public record class Carrier
{
    public int code {get;set;}

    public string title {get;set;} = String.Empty;

    public required CarrierCode codes {get;set;}
}
