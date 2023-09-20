using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
// using System;
// using System.Collections.Generic;

namespace tasksAPI.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IConnectionMultiplexer _redis;

        public MainController(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }
        // GET: api/MiControlador
        [HttpGet]
        public ActionResult<string> GetAllTasks()
        {
            IDatabase db = _redis.GetDatabase();
            string value = db.StringGet("Hola");
            return Ok(value);
        }
    }
}