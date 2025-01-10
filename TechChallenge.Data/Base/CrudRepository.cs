using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TechChallenge.Domain.Entities.Base;
using TechChallenge.Domain.Interface.BaseRepository;

namespace TechChallenge.Data.Base;
public class CrudRepository<T>(IConfiguration configuration) : ICrudRepository<T> where T : IEntity
{
    protected readonly string _connString = configuration["ConnectionStrings:ConnString"]!;

    public async Task<int> InsertAsync(T entity, CancellationToken cancellationToken = default)
    {
        var tableName = entity.GetType().Name;
        var properties = entity.GetType().GetProperties();

        var columnNames = string.Join(", ", properties.Select(p => p.Name));
        var parameterNames = string.Join(", ", properties.Select(p => $"@{p.Name}"));

        var insertSql = $"INSERT INTO dbo.{tableName} ({columnNames}) VALUES ({parameterNames})";

        using var conn = new SqlConnection(_connString);
        await conn.OpenAsync(cancellationToken);
        return await conn.ExecuteAsync(insertSql, param: entity);
    }

    public Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<List<T?>> RawQueryAsync(string sql, CancellationToken cancellationToken = default)
    {
        using var conn = new SqlConnection(_connString);
        await conn.OpenAsync(cancellationToken);
        return (await conn.QueryAsync<T?>(sql, cancellationToken)).ToList();
    }

    public async Task<T?> RawQueryFirstOrDefaultAsync(string sql, CancellationToken cancellationToken = default)
    {
        using var conn = new SqlConnection(_connString);
        await conn.OpenAsync(cancellationToken);
        return await conn.QueryFirstOrDefaultAsync<T?>(sql, cancellationToken);
    }
}
