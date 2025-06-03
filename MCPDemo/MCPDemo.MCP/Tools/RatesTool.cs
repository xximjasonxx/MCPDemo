using System.ComponentModel;
using MCPDemo.Common.ResponsModels;
using MCPDemo.MCP.Interfaces;
using ModelContextProtocol.Server;

namespace MCPDemo.MCP.Tools;

[McpServerToolType]
public class RatesTool(ICovidDataClient covidDataClient)
{
    [McpServerTool(Name = "GetCountryCaseRates")]
    [Description("Fetches the case rate information by month year time period for a given country as represented by a 2 charcter country code")]
    public async Task<List<CountryCaseChangeRateResponseModel>> GetCountryCaseChangeRates(string countyCode)
    {
        return await covidDataClient.GetCountryCaseChangeRates(countyCode);
    }
}