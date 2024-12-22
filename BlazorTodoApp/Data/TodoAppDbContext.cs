using BlazorTodoApp.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorTodoApp.Data
{
    public class TodoAppDbContext : DbContext
    {
        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; }

    }
}
