using FlightsBot.Web.Application;
using NodaTime;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();
builder.Services.ConfigureApplicationModules(builder.Configuration);
builder.Services.AddSingleton<IClock>(SystemClock.Instance); // TODO: ЗАЧЕМ, ЕСЛИ В DEPENDENCY INJECTION ЯВНО СОЗДАЕТСЯ ИНСТАНС!!!???

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // еще не ловил, но нужно посмотреть
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints => {
    _ = endpoints.MapControllers(); // подключаем маршрузитацию из контроллеров
});

app.Run();
