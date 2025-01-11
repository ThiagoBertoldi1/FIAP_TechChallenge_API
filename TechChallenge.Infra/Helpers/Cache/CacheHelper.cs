using System.Text;

namespace TechChallenge.Infra.Helpers.Cache;
public static class CacheHelper
{
    public static string CreateCacheKey<T>(T request)
    {
        var commandName = typeof(T).Name;

        var properties = request!.GetType().GetProperties();

        var sb = new StringBuilder();

        foreach (var prop in properties)
        {
            var valor = prop.GetValue(request);
            if (valor != null)
            {
                if (sb.Length > 0)
                {
                    sb.Append('_');
                }

                sb.Append($"{prop.Name}_{valor}");
            }
        }

        return commandName + '_' + sb.ToString();
    }
}
