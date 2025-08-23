using azurefncold.Domain;

namespace azurefncold.Infra;

public class TodoRepo
{
    public Task<IEnumerable<Todo>> GetTodos()
    {
        IEnumerable<Todo> todos = [
            new (Id: "1", Title: "Test"),
            new (Id: "2", Title: "Test 2")
        ];
        
        return Task.FromResult(todos);
    }
}