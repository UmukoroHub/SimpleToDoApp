using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace SimpleToDoApp.Models
{
        public class ToDoItem
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "Title is required.")]
            [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
            public string Title { get; set; }

            [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
            public string Description { get; set; }

            [Required]
            [Display(Name = "Created On")]
            [DataType(DataType.Date)]
            public DateTime CreatedDate { get; private set; } = DateTime.Now;

            [Required]
            [Display(Name = "Due Date")]
            [DataType(DataType.Date)]
            public DateTime? DueDate { get; set; }

            [Display(Name = "Is Completed")]
            public bool IsCompleted { get; set; }


        }
    


}
