using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ListaDeAfazeres.Models
{
	public class Notes
	{
		[Key]
		public int Id { get; set; }
		[Required]
		public string Content { get; set; }

		[ForeignKey("ToDo")]
		public int ToDoId { get; set; }
		public ToDo ToDo { get; set; }
	}
}
