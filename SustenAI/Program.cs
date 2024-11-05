using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using SustenAI.API.Services.Recommendation;
using SustenAI.Configuration;
using SustenAI.Extentions;
using SustenAI.Repository;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
AppConfiguration appConfiguration = new AppConfiguration();
configuration.Bind(appConfiguration);


builder.Services.AddSingleton<RecommendationService>();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDBContexts(appConfiguration);
builder.Services.AddSwagger(appConfiguration);
builder.Services.AddServices();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPrevisaoRepository, PrevisaoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
