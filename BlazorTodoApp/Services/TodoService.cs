using BlazorTodoApp.Contracts;
using BlazorTodoApp.Contracts.Services;
using BlazorTodoApp.Shared.Domain;

namespace BlazorTodoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<Todo>> GetAllTodos()
        {
            return await _todoRepository.GetAllTodos();
        }

        public async Task<Todo> GetTodoDetails(int todoId)
        {
            return await _todoRepository.GetTodoById(todoId);
        }

        public async Task<Todo> AddTodo(Todo todo)
        {
            return await _todoRepository.AddTodo(todo);
        }

        public async Task UpdateTodo(Todo todo)
        {
            await _todoRepository.UpdateTodo(todo);
        }

        public async Task DeleteTodo(int todoId)
        {
            await _todoRepository.DeleteTodo(todoId);
        }
    }
}
