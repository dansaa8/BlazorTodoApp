using BlazorTodoApp.Shared.Domain;

namespace BlazorTodoApp.Contracts.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> GetTodoDetails(int todoId);
        Task<Todo> AddTodo(Todo todo);
        Task UpdateTodo(Todo todo);
        Task DeleteTodo(int todoId);
    }
}
