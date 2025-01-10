namespace TechChallenge.Domain.Interface.BaseRepository;
public interface ICrudRepository<T>
{
    Task<int> InsertAsync(T entity, CancellationToken cancellationToken = new());
    Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = new());
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = new());
    Task<T?> RawQueryFirstOrDefaultAsync(string sql, CancellationToken cancellationToken = default);
    Task<List<T?>> RawQueryAsync(string sql, CancellationToken cancellationToken = default);
}
