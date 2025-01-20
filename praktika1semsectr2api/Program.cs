using Microsoft.EntityFrameworkCore;
using praktika1semsectr2api.DataBaseContext;
using praktika1semsectr2api.Interface;
using praktika1semsectr2api.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TestDbString")), ServiceLifetime.Scoped);

builder.Services.AddScoped<IUsercs, UserService>();

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
