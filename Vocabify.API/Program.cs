using Microsoft.EntityFrameworkCore;
using Vocabify.API.Data;
using Vocabify.API.Modules.Sets;
using Vocabify.API.Modules.Terms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add dbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlite("Data Source=local.db;");
});

// Add modules

builder.Services.AddSetsModule();
builder.Services.AddTermsModule();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
using (var scope = app.Services.CreateScope())
{
    DbInitializer.Seed(scope).Wait();
}

//app.UseHttpsRedirection();

app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.UseAuthorization();

app.MapControllers();

app.Run();
