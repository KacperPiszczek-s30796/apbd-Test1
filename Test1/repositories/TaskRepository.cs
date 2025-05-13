using System.Data;
using Microsoft.Data.SqlClient;
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
    public async Task<string> findTaskType(int id, CancellationToken token = default)
    {
        const string query = """
                              Select * from TaskType
                                 WHERE IdTaskType = @Id;
                             """;
        await using SqlConnection con = new(_connectionString);
        await using SqlCommand command = new SqlCommand(query, con);
        await con.OpenAsync(token);
        command.Parameters.AddWithValue("@Id", id);
        string result = "";
        using (SqlDataReader reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                result = reader.GetString(1);
            }
        }
        return result;
    }

    public async Task<string> findProjectName(int id, CancellationToken token = default)
    {
        const string query = """
                              Select * from Project
                                 WHERE IdProject = @Id;
                             """;
        await using SqlConnection con = new(_connectionString);
        await using SqlCommand command = new SqlCommand(query, con);
        await con.OpenAsync(token);
        command.Parameters.AddWithValue("@Id", id);
        string result = "";
        using (SqlDataReader reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                result = reader.GetString(1);
            }
        }
        return result;
    }

    public async Task<List<Task1>> findTasks(int id, CancellationToken token = default)
    {
        List<Task1> result = new List<Task1>();
        const string query = """
                              Select * from TaskType
                                 WHERE IdAssignedTo = @Id or IdCreator = @Id
                              Order By Deadline desc;
                             """;
        await using SqlConnection con = new(_connectionString);
        await using SqlCommand command = new SqlCommand(query, con);
        await con.OpenAsync(token);
        command.Parameters.AddWithValue("@Id", id);
        using (SqlDataReader reader = await command.ExecuteReaderAsync())
        {
            // Read results asynchronously
            while (await reader.ReadAsync())
            {
                result.Add(new Task1()
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Deadline = reader.GetDateTime(3),
                    ProjectName = findProjectName(reader.GetInt32(4), token).Result,
                    Type = findTaskType(reader.GetInt32(5), token).Result
                });
            }
        }
        return result;
    }
    
}