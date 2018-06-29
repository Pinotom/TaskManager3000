using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;


namespace DAL
{
    public class DataAccess
    {
        private TaskContext _context;

        public DataAccess()
        {
            _context = new TaskContext();
        }

        public IEnumerable<Task> GetTasks()
        {
            var tasks = _context.Tasks.Include(t => t.User).Include(t => t.Status).ToList();

            return tasks;
        }

        public void AddTask(Task task)
        {
            if (task != null)
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
        }

        public void DeleteTask(int id)
        {
            var taskToDelete = _context.Tasks.SingleOrDefault(t => t.Id == id);

            if (taskToDelete == null)
            {
                throw new ArgumentException("The task was not found.");
            }

            _context.Tasks.Remove(taskToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<TaskStatus> GetTaskStatuses()
        {
            var taskstatuses = _context.TaskStatuses.Include(t => t.Tasks).ToList();

            return taskstatuses;
        }

        public IEnumerable<User> GetUsers()
        {
            var users = _context.Users.ToList();

            return users;
        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public User GetUser(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }

        public void MoveTask(int id, int newStatus, User user)
        {
            var taskToEdit = _context.Tasks.SingleOrDefault(t => t.Id == id);

            if (taskToEdit == null)
            {
                throw new ArgumentException("The task was not found.");
            }
            if (taskToEdit.TaskStatusId == 1)
            {
                taskToEdit.UserId = user.Id;
            }
            if (newStatus == 1)
            {
                taskToEdit.UserId = null;
            }
            taskToEdit.TaskStatusId = newStatus;
            _context.SaveChanges();
        }

        public Task GetTask(int id)
        {
            var task = _context.Tasks.SingleOrDefault(t => t.Id == id);

            return task;
        }
    }
}
