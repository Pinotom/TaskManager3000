using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class Task
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int TaskStatusId { get; set; }

        public virtual User User { get; set; }
        public virtual TaskStatus Status { get; set; }
    }
}
