using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using Microsoft.Data.SqlClient;
using TonicTodoList;

public class TodoListDbContext : DbContext
{
    public DbSet<TodoListItem>? TodoListItems { get; set; }

    public TodoListDbContext(DbContextOptions<TodoListDbContext> dbContextOptions) : base(dbContextOptions) { }
}
