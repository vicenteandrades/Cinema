using APIFilmeStudy.Model;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace APIFilmeStudy.Context;
public class FilmeContext : DbContext
{
    public NpgsqlConnection Connect { get; set; }

	public FilmeContext(DbContextOptions<FilmeContext> options) : base(options)
	{
		Connect = new NpgsqlConnection("Host = localhost; Port=5432; Database=FilmeStudy; Username=postgres; Password=1440");
    }

	protected override void OnConfiguring(DbContextOptionsBuilder builder)
	{
		base.OnConfiguring(builder);
		builder.UseNpgsql(Connect);
	}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

	public DbSet<Filme> Filme { get; set; }
	public DbSet<Endereco> Endereco { get; set; }
	public DbSet<Cinema> Cinema { get; set; }
	public DbSet<Sessao> Sessao { get; set; }
}

