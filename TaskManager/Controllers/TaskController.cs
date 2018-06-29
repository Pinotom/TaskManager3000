using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TaskManager.ViewModels;

namespace TaskManager.Controllers
{
    public class TaskController : Controller
    {
        private DataAccess _dal = new DataAccess();
        public ActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            try
            {
                viewModel.Users = _dal.GetUsers();
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("_Error");
            }

            return View(viewModel);
        }

        public ActionResult LogIn(User user)
        {

            try
            {
                Session["User"] = _dal.GetUser(user.Id);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("_Error");
            }


            return RedirectToAction("Tasks", "Task");
        }

        public ActionResult NewUser(User user)
        {
            if (!ModelState.IsValid)
            {
                IndexViewModel viewModel = new IndexViewModel
                {
                    Users = _dal.GetUsers(),
                    User = user
                };
                return View("Index", viewModel);
            }

            try
            {
                _dal.AddUser(user);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("_Error");
            }


            return RedirectToAction("LogIn", "Task", user);
        }

        public ActionResult Tasks()
        {
            return View(GetTasksViewModel());
        }

        public ActionResult MoveTask(int id, int newStatus)
        {
            try
            {
                _dal.MoveTask(id, newStatus, (User)Session["User"]);
            }
            catch (ArgumentException e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("_Error");

            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("_Error");
            }

            return RedirectToAction("Tasks", "Task");
        }

        public ActionResult DeleteTask(int id)
        {

            IEnumerable<Task> model;
            try
            {
                Task task = _dal.GetTask(id);
                int statusId = task.TaskStatusId;
                _dal.DeleteTask(id);
                var tasks = _dal.GetTasks();
                model = tasks.Where(t => t.TaskStatusId == statusId);
            }
            catch (ArgumentException e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("_Error");

            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("_Error");
            }

            return PartialView("_TasksPartial", model);
        }

        [HttpPost]
        public ActionResult NewTask(Task task)
        {
            if (!ModelState.IsValid)
            {
                TasksViewModel viewModel = GetTasksViewModel();
                viewModel.Task = task;
                return View("Tasks", viewModel);
            }

            task.TaskStatusId = 1;

            try
            {
                _dal.AddTask(task);
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                return View("_Error");
            }


            return RedirectToAction("Tasks", "Task");
        }

        private TasksViewModel GetTasksViewModel()
        {
            return new TasksViewModel
            {
                Tasks = _dal.GetTasks(),
                TaskStatuses = _dal.GetTaskStatuses(),
            };
        }
    }
}