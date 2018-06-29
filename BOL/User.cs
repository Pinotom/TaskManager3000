using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BOL
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }


        public virtual ICollection<Task> Tasks { get; set; }
    }
}
