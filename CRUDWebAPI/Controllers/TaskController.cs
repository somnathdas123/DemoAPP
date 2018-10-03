using CRUDWebAPI.Models;
using CRUDWebAPI.Services;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CRUDWebAPI.Controllers
{
    [RoutePrefix("Task")]
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]
    public class TaskController : ApiController
    {
        private ITaskServices _itaskServices;

        public TaskController(ITaskServices itaskServices)
        {
            _itaskServices = itaskServices;
        }

        // Get task list.
        [Route("GetTasks")]       
        public IEnumerable<Task> GetTaskList()
        {
            return _itaskServices.GetTaskList();
        }

        // Add new task.
        [Route("AddTask")]
        [HttpPost]
        public string AddTask(Task taskObject)
        {
            var result = _itaskServices.AddTask(taskObject);
            return result.ToString();
        }

        // Delete task.
        [Route("DeleteTask/{id}")]
        [HttpPost]
        public string Delete(string id)
        {
            var result = 0;
            int taskId = 0;
            int.TryParse(id, out taskId);
            if(taskId> 0)
                result = _itaskServices.RemoveTask(taskId);
            return result.ToString();
        }

        // Get task by id.
        [Route("GetTask/{id}")]
        public Task GetTaskByID(string id)
        {
            int taskId = 0;
            int.TryParse(id, out taskId);
            if (taskId > 0)
                return _itaskServices.GetTaskByID(taskId);
            return null;
        }

        // Edit task.
        [Route("EditTask")]
        [HttpPost]
        public string EditTask(Task taskObject)
        {
            var result = _itaskServices.EditTask(taskObject);
            return result.ToString();
        }
    }
}
