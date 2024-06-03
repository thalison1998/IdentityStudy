using IdentityStudy.Data;
using IdentityStudy.Domain.Entities;
using IdentityStudy.Service;
using IdentityStudy.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddDefaultIdentity<UserCustom>()
                .AddEntityFrameworkStores<DataContext>();

builder.Services.AddDbContext<DataContext>(options => 
options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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
