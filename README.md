Выполняю в /src:
dotnet ef migrations add InitialCreate --project FlightsBot.Infrustructure.Implementation.DataAccess  --startup-project FlightsBot.Web --verbose

Получаю ошибку:
Your startup project 'FlightsBot.Web' doesn't reference Microsoft.EntityFrameworkCore.Design. This package is required for the Entity Framework Core Tools to work. Ensure your startup project is correct, install the package, and try again.

Вопрос:
Почему Web не использует зависимости FlightsBot.Infrustructure.Implementation.DataAccess? Там ведь есть Microsoft.EntityFrameworkCore.Design
