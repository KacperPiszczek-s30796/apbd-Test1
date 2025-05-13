using Test1.entities;

namespace Test1.repositories.abstractions;

public interface ItaskRepository
{
    public Task<string> findTaskType(int id, CancellationToken token = default);
    public Task<string> findProjectName(int id, CancellationToken token = default);
    public Task<List<Task1>> findTasks(int id, CancellationToken token = default);
}