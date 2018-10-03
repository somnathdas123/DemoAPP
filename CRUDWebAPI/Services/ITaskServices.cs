using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRUDWebAPI.Models;

namespace CRUDWebAPI.Services
{
    public interface ITaskServices
    {
        IEnumerable<Task> GetTaskList();
        int AddTask(Task taskObject);
        int RemoveTask(int taskID);
        Task GetTaskByID(int taskID);
        int EditTask(Task taskObject);
    }
}