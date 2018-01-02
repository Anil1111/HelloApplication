using System.ComponentModel.DataAnnotations;

namespace HelloApplication.Models
{
	public class Message
	{
        public int Id { get; set; }
        [Required(ErrorMessage="Введите текст")]
        [DataType(DataType.MultilineText)]
		public string Post { get; set; }
	}
}