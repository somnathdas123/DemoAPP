using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDWebAPI.Models;

namespace CRUDWebAPI.Services
{
    /// <summary>
    /// Task services class to perform ADD/UPDATE/DELETE/GET operations
    /// </summary>
    public class TaskServices : ITaskServices
    {        
        public IEnumerable<Task> GetTaskList()
        {
            TasksDBContext context = new Models.TasksDBContext();
            return context.Tasks.ToList();
        }

        public int AddTask(Task taskObject)
        {
            TasksDBContext context = new Models.TasksDBContext();
            Task t = new Task();
            t.TaskName = taskObject.TaskName;
            t.Priority = taskObject.Priority;
            t.TaskDate = taskObject.TaskDate;
            t.EstimatedCost = taskObject.EstimatedCost;
            t.Description = taskObject.Description;
            context.Tasks.Add(t);
            return context.SaveChanges();
        }

        public int RemoveTask(int taskID)
        {
            var result = 0;
            TasksDBContext context = new Models.TasksDBContext();
            var task = context.Tasks.FirstOrDefault(i => i.TaskId == taskID);
            if(task != null)
            {
                context.Tasks.Remove(task);
                result = context.SaveChanges();
            }
            return result;
        }

        public Task GetTaskByID(int taskID)
        {
            TasksDBContext context = new Models.TasksDBContext();
            var task = context.Tasks.FirstOrDefault(i => i.TaskId == taskID);
            if (task != null)
            {
                return task;
            }
            else
            {
                return null;
            }
        }

        public int EditTask(Task taskObject)
        {
            TasksDBContext context = new Models.TasksDBContext();
            var task = context.Tasks.FirstOrDefault(i => i.TaskId == taskObject.TaskId);
            if (task != null)
            {                
                task.TaskName = taskObject.TaskName;
                task.Priority = taskObject.Priority;
                task.TaskDate = taskObject.TaskDate;
                task.EstimatedCost = taskObject.EstimatedCost;
                task.Description = taskObject.Description;
                return context.SaveChanges();
            }
            else
            {
                return 0;
            }
        }
    }
}