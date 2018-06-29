using BOL;
using System.Collections.Generic;

namespace TaskManager.ViewModels
{
    public class IndexViewModel
    {
        public User User { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}