using ListaDeAfazeres.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDeAfazeres.Data
{
	public class AppDbContext : DbContext 
	{
		public AppDbContext (DbContextOptions<AppDbContext> options) : base ( options) { }

		DbSet<ToDo> ToDo { get; set; }

		DbSet<Notes> Notes { get; set; }

	}
}
