using DergiOrtak;
using DergiOrtak.DataAccsess;
using DergiOrtak.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DergiDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDataHandler, DataHandler>();
builder.Services.AddScoped<IDergiService, DergiService>();
builder.Services.AddScoped<ISayiService, SayiService>();
builder.Services.AddScoped<IMakaleService, MakaleService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
