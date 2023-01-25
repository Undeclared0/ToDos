using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ToDos.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Display(Name = "Task"), Required]
        public string? ToDo { get; set; }
        public string? Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Last updated on")]
        public string? UpdatedDate { get; set; }

        [Display(Name ="Status")]
        public string? Status { get; set; }
        public bool ? IsCompleted { get; set; }


    }
}
