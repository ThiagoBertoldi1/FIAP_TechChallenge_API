namespace TechChallenge.Domain.Interface.BaseRepository;
public interface ICrudRepository<T>
{
    Task<int> InsertAsync(T entity, CancellationToken cancellationToken = new());
    Task<int> UpdateAsync(T entity, CancellationToken cancellationToken = new());
    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = new());
    protected Task<T?> RawQueryFirstOrDefaultAsync(string sql, CancellationToken cancellationToken = default);
    protected Task<List<T>> RawQueryAsync(string sql, CancellationToken cancellationToken = default);
}
