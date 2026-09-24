using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowAll");

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

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Billetera> Billetera { get; set; }
}

[Table("billetera")]
  public class Billetera
  {
    [Column("id")]
    public int Id { get; set; }
    [Column("nombres")]
    public string Nombres { get; set; }

    [Column("apellidos")]
    public string Apellidos { get; set; }

    [Column("tipodoc")]
    public string TipoDoc { get; set; }

    [Column("documento")]
    public int Documento { get; set; }

    [Column("valorreacarga")]
    public int valorReacarga { get; set; }

    [Column("formapago")]
    public string FormaPago { get; set; }
}
