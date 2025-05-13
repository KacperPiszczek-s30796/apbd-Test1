using Microsoft.Data.SqlClient;
using Test1.entities;
using Test1.repositories.abstractions;

namespace Test1.repositories;

public class TeamMemberRepository: ITeamMemberRepository
{
    private readonly string _connectionString;

    public TeamMemberRepository(IConfiguration cfg)
    {
        _connectionString = cfg.GetConnectionString("Default") ??
                            throw new ArgumentNullException(nameof(cfg),
                                "Default connection string is missing in configuration");
    }
    public async Task<TeamMember> findTeamMember(int id, CancellationToken token = default)
    {
        const string query = """
                              Select * from TeamMember
                                 WHERE IdTeamMember = @Id;
                             """;
        await using SqlConnection con = new(_connectionString);
        await using SqlCommand command = new SqlCommand(query, con);
        await con.OpenAsync(token);
        command.Parameters.AddWithValue("@Id", id);
        TeamMember result = new TeamMember();
        using (SqlDataReader reader = await command.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync())
            {
                    result.FirstName = reader.GetString(1);
                    result.LastName = reader.GetString(2);
                    result.Email = reader.GetString(3);
            }
        }
        return result;
    }
}