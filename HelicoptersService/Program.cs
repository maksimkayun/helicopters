using HelicoptersService.Configuration;
using HelicoptersService.Services;
using HelicoptersProcessService = HelicoptersService.Services.HelicoptersService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<HelicoptersMongoDbSettings>(builder.Configuration.GetSection("HelicoptersDatabase"));
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddSingleton<IHelicopterService, HelicoptersProcessService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();