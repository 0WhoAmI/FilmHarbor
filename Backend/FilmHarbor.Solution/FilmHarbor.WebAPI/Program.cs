var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddDbContext<FilmHarborDbContext>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
//});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// SPRAWDZIC
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});
//

app.UseAuthorization();

app.MapControllers();

app.Run();
