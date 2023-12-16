using TestProject.BusinessLayer.Abstract;
using TestProject.DataAccessLayer.Abstact;
using TestProject.DataAccessLayer.Concrete;
using TestProject.DataAccessLayer.EntityFramework;
using TestProject.BusinessLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IStaffDal, EfStaffDal>();
builder.Services.AddScoped<IStaffService, StaffManager>();

builder.Services.AddCors(opt=>
{
    opt.AddPolicy("TestApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    }
    );
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("TestApiCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
