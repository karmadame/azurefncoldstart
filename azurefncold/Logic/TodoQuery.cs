using azurefncold.Domain;
using azurefncold.Infra;

namespace azurefncold.Logic;

public class TodoQuery(Lazy<TodoRepo> todoRepo)
{
    
    public async Task<IEnumerable<Todo>> GetTodos()
    {
       return await todoRepo.Value.GetTodos();   
    }
}