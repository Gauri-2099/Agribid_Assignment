using Agribid_Assignment;
using Agribid_Assignment.BL;
using Agribid_Assignment.Data;
using Microsoft.EntityFrameworkCore;




var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CustomerDbContext>(options =>
{
    var configuration = builder.Configuration;
    options.UseSqlServer(configuration.GetConnectionString("ConnStr"));
});
      

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

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
