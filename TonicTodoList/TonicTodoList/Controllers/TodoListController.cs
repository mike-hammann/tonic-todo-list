using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TonicTodoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ILogger<TodoListController> _logger;

        public TodoListController(ILogger<TodoListController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTodoList")]
        public IEnumerable<TodoListItem> Get()
        {
            return Array.Empty<TodoListItem>();
        }
    }
}