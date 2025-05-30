using System.Net;
using Newtonsoft.Json;

namespace MCPDemo.MCP.Clients;

public class ClientBase(HttpClient httpClient)
{
    protected async Task<TReturn> InvokeGetRequest<TReturn>(string uriPart)
    {
        var response = await httpClient.GetAsync("/api/v1/countries");
        response.EnsureSuccessStatusCode();
        
        var responseContent = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrWhiteSpace(responseContent))
        {
            throw new HttpRequestException("Response content is empty.", null, HttpStatusCode.BadRequest);
        }

        var returnResult = JsonConvert.DeserializeObject<TReturn>(responseContent);
        if (returnResult is null)
        {
            throw new HttpRequestException("Response content did not deserialize to target type.", null, HttpStatusCode.BadRequest);
        }
        
        return returnResult;
    }
}