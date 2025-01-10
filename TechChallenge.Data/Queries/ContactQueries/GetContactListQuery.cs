using TechChallenge.Domain.Commands.ContactCommands.Select;

namespace TechChallenge.Data.Queries.ContactQueries;
public class GetContactListQuery(GetContactListCommand filters)
{
    private readonly GetContactListCommand Filters = filters;

    private readonly List<string> _conditions = [];

    private string _sql = string.Empty;

    public string GetSql()
    {
        _sql = $@"SELECT * FROM dbo.Contact WITH (NOLOCK)";

        if (!string.IsNullOrEmpty(Filters.Id.ToString()))
            _conditions.Add($"Id = '{Filters.Id}' ");

        if (!string.IsNullOrEmpty(Filters.DDD.ToString()))
            _conditions.Add($"SUBSTRING(CAST(PhoneNumber AS VARCHAR(11)), 1, 2) LIKE '%' + '{Filters.DDD}' + '%' ");

        if (!string.IsNullOrEmpty(Filters.Name))
            _conditions.Add($"Name LIKE '%' + '{Filters.Name}' + '%' ");

        if (!string.IsNullOrEmpty(Filters.Email))
            _conditions.Add($"Email LIKE '%' + '{Filters.Email}' + '%' ");

        if (!string.IsNullOrEmpty(Filters.PhoneNumber.ToString()))
            _conditions.Add($"PhoneNumber LIKE '%' + '{Filters.PhoneNumber}' + '%' ");

        if (!string.IsNullOrEmpty(Filters.Region))
            _conditions.Add($"Region LIKE '%' + '{Filters.Region}' + '%' ");

        if (!string.IsNullOrEmpty(Filters.District))
            _conditions.Add($"District LIKE '%' + '{Filters.District}' + '%' ");

        return ConcatConditions();
    }

    public string ConcatConditions()
    {
        if (_conditions.Count == 0)
            return _sql + Pagination();

        return _sql + " WHERE " + string.Join(" AND ", _conditions) + Pagination();
    }

    public string Pagination()
    {
        return $" ORDER BY Id "
            + $"OFFSET {Math.Max(Filters.ItemsPerPage, 1)} * ({Math.Max(Filters.Page, 1) - 1}) ROWS "
            + $"FETCH NEXT {Math.Max(Filters.ItemsPerPage, 1)} ROWS ONLY;";
    }
}
