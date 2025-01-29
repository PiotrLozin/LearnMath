using LearnMath.Application;
using LearnMath.Application.OpenStreetMap;
using LearnMath.Application.Opinions;
using LearnMath.Application.Students;
using LearnMath.Application.Teachers;
using LearnMath.Application.Users;
using LearnMath.Infrastructure.DataAccess;
using LearnMath.Infrastructure.ExternalApis;
using LearnMath.Infrastructure.Opinions;
using LearnMath.Infrastructure.Users;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LearnMathContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOpinionRepository, OpinionRepository>();
builder.Services.AddScoped<IOpenStreetMapService, OpenStreetMapService>();
builder.Services.AddHttpClient<IOpenStreetMapService, OpenStreetMapService>(client =>
{
    client.DefaultRequestHeaders.Add("User-Agent", "LearnMath/1.0 (testaplikacji@wp.pl)");
    client.BaseAddress = new Uri("https://nominatim.openstreetmap.org/");
});

builder.Services.AddMediatR(cfg => 
{
    cfg.RegisterServicesFromAssembly(typeof(IApplicationMarker).Assembly);
});

builder.Services.AddCors(options =>
 {
     options.AddPolicy(name: "AllPolicy",
                       policy =>
                       {
                           //policy.WithOrigins("http://localhost:4200").AllowAnyHeader();
                           policy.AllowAnyOrigin().WithMethods(
                               HttpMethod.Get.Method,
                               HttpMethod.Put.Method,
                               HttpMethod.Post.Method,
                               HttpMethod.Delete.Method).AllowAnyHeader();
                       });
 });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
