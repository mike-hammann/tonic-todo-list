using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TonicTodoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoListController : ControllerBase
    {
        private readonly ILogger<TodoListController> _logger;


        private readonly TodoListDbContext _context;

        public TodoListController(ILogger<TodoListController> logger, TodoListDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetTodoList")]
        public IEnumerable<TodoListItem> Get()
        {
            using (_context)
            {
                var items = _context.ListEntries;
                if (items == null)
                {
                    return Array.Empty<TodoListItem>();
                }
                return items.ToArray();
            }
        }
    }
}