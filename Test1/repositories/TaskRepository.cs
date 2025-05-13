using Test1.entities;
using Test1.repositories.abstractions;

namespace Test1.repositories;

public class TaskRepository: ItaskRepository
{
    private readonly string _connectionString;

    public TaskRepository(IConfiguration cfg)
    {
        _connectionString = cfg.GetConnectionString("Default") ??
                            throw new ArgumentNullException(nameof(cfg),
                                "Default connection string is missing in configuration");
    }
    public Task<string> findTaskType(int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<string> findProjectName(int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }

    public Task<List<Task1>> findTasks(int id, CancellationToken token = default)
    {
        throw new NotImplementedException();
    }
    
}