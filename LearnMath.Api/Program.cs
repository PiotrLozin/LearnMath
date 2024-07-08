using LearnMath.Application.Services.Implementations;
using LearnMath.Application.Services.Interfaces;
using LearnMath.Application.Students;
using LearnMath.Application.Teachers;
using LearnMath.Infrastructure.DataAccess;
using LearnMath.Infrastructure.Students;
using LearnMath.Infrastructure.Teachers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LearnMathContext>();

builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddCors(options =>
 {
     options.AddPolicy(name: "AllPolicy",
                       policy =>
                       {
                           policy.WithOrigins("http://localhost:4200").AllowAnyHeader();
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
