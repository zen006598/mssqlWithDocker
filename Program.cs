using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using mssqlWithDocker.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("MssqlConnection"))
{
    Password = builder.Configuration["MssqlConnection:Password"]
};
var mssqlConnection = conStrBuilder.ConnectionString;

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(mssqlConnection));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();