using Newtonsoft.Json;
using TechChallenge.Infra.Exceptions;

namespace TechChallenge.Infra.Helpers.DDD;
public class GetDDDHelper
{
    private static readonly HttpClient _httpClient = new();
    private readonly string _baseUrl = "https://brasilapi.com.br/api/ddd/v1/";

    public async Task<(string region, string district)> GetDDDInfo(int ddd)
    {
        var response = await _httpClient.GetAsync(_baseUrl + ddd);

        if (!response.IsSuccessStatusCode)
            throw new ApiTechChallengeException(System.Net.HttpStatusCode.BadRequest, ["Distrito/Região não encontrados"]);

        var district = JsonConvert.DeserializeObject<ApiDDDResponse>(await response.Content.ReadAsStringAsync())!.state;

        if (string.IsNullOrEmpty(district))
            throw new ApiTechChallengeException(System.Net.HttpStatusCode.BadRequest, ["Distrito não encontrado"]);

        var region = GetRegion(district);

        if (string.IsNullOrEmpty(region))
            throw new ApiTechChallengeException(System.Net.HttpStatusCode.BadRequest, ["Região não encontrada"]);

        return (region, district);
    }

    private static string GetRegion(string district)
        => district switch
        {
            "SC" or "RS" or "PR" => "Sul",
            "AC" or "AP" or "AM" or "PA" or "RO" or "RR" or "TO" => "Norte",
            "DF" or "GO" or "MT" or "MS" => "Centro-Oeste",
            "ES" or "MG" or "RJ" or "SP" => "Sudeste",
            "AL" or "BA" or "CE" or "MA" or "PB" or "PE" or "PI" or "RN" or "SE" => "Nordeste",
            _ => string.Empty
        };
}
