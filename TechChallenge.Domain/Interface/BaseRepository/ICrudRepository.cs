namespace TechChallenge.Domain.Interface.BaseRepository;
public interface ICrudRepository<T>
{
    Task<bool> InsertAsync(T entity, CancellationToken cancellationToken = new());
    Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = new());
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = new());
    Task<T?> GetById(Guid id, CancellationToken cancellationToken = new());
    protected Task<T?> RawQueryFirstOrDefaultAsync(string sql, CancellationToken cancellationToken = default);
    protected Task<List<T>> RawQueryAsync(string sql, CancellationToken cancellationToken = default);
}
