using ListaDeAfazeres.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeAfazeres.Data
{
	public class AppDbContext : DbContext 
	{
		public AppDbContext (DbContextOptions<AppDbContext> options) : base ( options) { }

		public DbSet<ToDo> ToDo { get; set; }

		public DbSet<Notes> Notes { get; set; }

	}
}
