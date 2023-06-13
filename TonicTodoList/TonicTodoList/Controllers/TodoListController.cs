using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

        [HttpPost(Name = "AddTodoListItem")]
        public HttpStatusCode Post(TodoListItem todoListItem)
        {
            using (_context)
            {
                try
                {
                    _context.Add(todoListItem);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return HttpStatusCode.InternalServerError;
                }
            }
            return HttpStatusCode.OK;
        }

        [HttpDelete(Name = "DeleteTodoListItem")]
        public HttpStatusCode DeleteItem(int id)
        {
            using (_context)
            {
                var itemList = _context.ListEntries;
                if (itemList == null)
                {
                    return HttpStatusCode.InternalServerError;
                }
                var item = itemList.Find(id);
                if (item == null)
                {
                    return HttpStatusCode.NotFound;
                }
                try
                {
                    _context.Remove(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return HttpStatusCode.InternalServerError;
                }
                return HttpStatusCode.OK;
            }
        }

        [HttpPut(Name = "CheckTodoListItem")]
        public HttpStatusCode CheckItem(int id)
        {
            using (_context)
            {
                var itemList = _context.ListEntries;
                if (itemList == null)
                {
                    return HttpStatusCode.InternalServerError;
                }
                var item = itemList.Find(id);
                if(item == null)
                {
                    return HttpStatusCode.NotFound;
                }
                try{
                    item.Done = true;
                    _context.Update(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    return HttpStatusCode.InternalServerError;
                } 
                return HttpStatusCode.OK;
            }
        }
    }
}