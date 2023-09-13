using Microsoft.AspNetCore.Mvc;
// using System;
// using System.Collections.Generic;

namespace tasksAPI.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class MainController : ControllerBase
    {
        // GET: api/MiControlador
        [HttpGet]
        public string[] GetAllTasks()
        {
            return new string[]{"Tarea 1","Tarea 2", "Tarea 3"};
        }

    }
}