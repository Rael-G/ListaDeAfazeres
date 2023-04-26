using System.ComponentModel.DataAnnotations;

namespace ListaDeAfazeres.Models
{
	public class ToDo
	{
		[Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content{ get; set; }
        [Required]
        public bool IsComplete { get; set; }
        
        public ICollection<Notes> Notes { get; set; } = new List<Notes>();

        public void AddNote (Notes note)
        {
            Notes.Add (note);
        }



    }
}
