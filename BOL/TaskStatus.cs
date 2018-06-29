using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOL
{

    public enum TaskStatusEnum { NotCheckedOut = 1, CheckedOut, Done }
    public class TaskStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public virtual ICollection<Task> Tasks { get; set; }
    }
}
