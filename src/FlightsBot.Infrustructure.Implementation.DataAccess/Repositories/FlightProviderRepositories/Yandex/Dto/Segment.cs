namespace FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex.Dto;

public record class Segment
{
    public required Thread thread {get;set;}

    public string departure {get;set;} = String.Empty;

    public string arrival {get;set;} = String.Empty;

    public double duration {get;set;}
}
