using BlazorTodoApp.Shared.Domain;

namespace BlazorTodoApp.Contracts
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetAllTodos();
        Task<Todo> GetTodoById(int todoId);
        Task<Todo> AddTodo(Todo todo);
        Task<Todo> UpdateTodo(Todo todo);
        Task DeleteTodo(int todoId);
    }
}
