using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TechTitansAPI.Data;
using TechTitansAPI.Services.AppUser;
using TechTitansAPI.Services.Company;
using TechTitansAPI.Services.Picture;
using TechTitansAPI.Services.Tree;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<ITreeService, TreeService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IPictureService, PictureService>();


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
