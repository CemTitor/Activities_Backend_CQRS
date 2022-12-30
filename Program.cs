using ActivitiesCQRS.Services;

using ActivitiesCQRS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddCors();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));


// Add the ActivityContext with PostgreSQL
builder.Services.AddDbContext<ActivityContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("ActivityDb")));

builder.Services.AddScoped<IActivityService,ActivityService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");


app.UseHttpsRedirection();

app.UseRouting();


app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.MapControllers();

app.CreateDbIfNotExists();



app.Run();
