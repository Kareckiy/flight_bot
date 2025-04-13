using System.Text.Json;
using System.Web;
using FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex.Responses;

namespace FlightsBot.Infrustructure.Implementation.DataAccess.Repositories.FlightProviderRepositories.Yandex.Clients;

public class YandexClient
{
    static HttpClient client = new();

    private string url = "api.rasp.yandex.net";
    private string apiKey = "c31b7e21-3d95-4727-bf4a-5ae06265604d";

    public YandexClient()
    {
        //client.BaseAddress = new Uri("https://api.rasp.yandex.net/v3.0/");
    }

    public async Task<GetFlightsListResponse?> GetFlightsAsync()
    {
        // TODO: плохо выглядит; но без конкатенеации base address не участвует в запросе
        var builder = new UriBuilder("https://api.rasp.yandex.net/v3.0/" + "search");

        var query = HttpUtility.ParseQueryString(builder.Query);

        query["apikey"] = "c31b7e21-3d95-4727-bf4a-5ae06265604d";
        query["format"] = "json";
        query["from"] = "LED";
        query["to"] = "VKO";
        query["lang"] = "ru_RU";
        query["transport_types"] = "plane";
        query["system"] = "iata";
        query["date"] = "2025-03-20";
        query["page"] = "1";

        builder.Query = query.ToString();
        string url = builder.ToString();

        //HttpResponseMessage response = await client.GetAsync("https://api.rasp.yandex.net/v3.0/search/?apikey=c31b7e21-3d95-4727-bf4a-5ae06265604d&format=json&from=LED&to=AYT&lang=ru_RU&page=1&date=2025-03-20&transport_types=plane&system=iata");
        HttpResponseMessage response = await client.GetAsync(url);

        var result = await response.Content.ReadAsStringAsync();

        GetFlightsListResponse? getFlightsListResponse = JsonSerializer.Deserialize<GetFlightsListResponse>(result);

        return getFlightsListResponse;
    }

    // публичный метод получения списка полетов с фильтрацией
    // приватный метод авторизации
}

/*
https://api.rasp.yandex.net/v3.0/search/?apikey=c31b7e21-3d95-4727-bf4a-5ae06265604d&format=json&from=LED&to=AYT&lang=ru_RU&page=1&date=2025-03-20&transport_types=plane&system=iata
*/