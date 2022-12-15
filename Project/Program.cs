using Project.Extensions;

var builder = WebApplication.CreateBuilder(args);

// dodanie kontrolerów
builder.Services.AddControllers();
// dodanie bazy danych
builder.Services.AddDatabase(builder);
// dodanie swaggera
builder.Services.AddSwaggerExtension();
// dodanie serwisów
builder.Services.AddServices();
// dodanie walidacji
builder.Services.AddValidation();
// dodanie mappera
builder.Services.AddMapper();
// dodanie tokenu JWT
builder.Services.AddAuthenticationExtension(builder);
// dodanie autoryzacji
builder.Services.AddAuthorizationExtension();
// dodanie CQRS
builder.Services.AddMediatREntension();
// dodanie logów i konfiguracja
builder.Host.UseSerilogConfiguration();

var app = builder.Build();

app.UseOpenApi();

// dodanie middleware - Exception handler
app.UseExceptionExtension();

app.RunAuthorization();

app.MapControllers();
app.Run();
