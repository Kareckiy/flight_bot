namespace FlightsBot.UseCases;

public class PullFlightsCommand
{
    private readonly YandexClient YandexClient;

    public PullFlightsCommand(YandexClient yandexClient)
    {
        YandexClient = yandexClient;
    }

    public async Task<bool> GetFlightsAsync()
    {
        var Flights = await YandexClient.GetFlightsAsync();

        if (Flights?.segments == null)
        {
            return false;
        }

        foreach (Segment segment in Flights.segments)
        {
            
        }

        return true;
    }
}
