
using BusinessLogicLayer.Service;
using DataAccessLayer.Interface;
using DataAccessLayer.Repository;
using Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingDetailRepository, BookingDetailRepository>();
builder.Services.AddScoped<IHomeStayRepository, HomeStayRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<HomeStayService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

/*builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy => { policy.AllowAnyMethod().AllowAnyHeader().AllowAnyMethod(); });
});*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(p => p
  .AllowAnyHeader()
  .AllowAnyMethod()
  .AllowAnyOrigin()
);
app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();
