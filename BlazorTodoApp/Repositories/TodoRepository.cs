using BlazorTodoApp.Contracts;
using BlazorTodoApp.Data;
using BlazorTodoApp.Shared.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorTodoApp.Repositories
{
    public class TodoRepository : ITodoRepository, IDisposable
    {
        private readonly TodoAppDbContext _dbContext;

        public TodoRepository(IDbContextFactory<TodoAppDbContext> DbFactory)
        {
            _dbContext = DbFactory.CreateDbContext();
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _dbContext.Todos.ToListAsync();
        }

        public async Task<Todo> GetTodoById(int todoId)
        {
            return await _dbContext.Todos.FirstOrDefaultAsync(t => t.TodoId == todoId);
        }

        public async Task<Todo> AddTodo(Todo todo)
        {
            var addedEntity = await _dbContext.Todos.AddAsync(todo);
            await _dbContext.SaveChangesAsync();
            return addedEntity.Entity;
        }
        public async Task<Todo> UpdateTodo(Todo todo)
        {
            var foundTodo = await _dbContext.Todos.FirstOrDefaultAsync(t => t.TodoId == todo.TodoId);

            if (foundTodo != null)
            {
                foundTodo.Title = todo.Title;
                foundTodo.Description = todo.Description;
                foundTodo.StartTime = todo.StartTime;
                foundTodo.EndTime = todo.EndTime;

                await _dbContext.SaveChangesAsync();
                return foundTodo;
            }
            return null;
        }

        public async Task DeleteTodo(int todoId)
        {
            var foundTodo = await _dbContext.Todos.FirstOrDefaultAsync(_ => _.TodoId == todoId);
            if (foundTodo is null) return;

            _dbContext.Todos.Remove(foundTodo);
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
