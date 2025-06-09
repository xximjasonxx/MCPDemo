from mcp.client.streamable_http import streamablehttp_client
from mcp import ClientSession

import json

MCP_SERVER_URL = "https://aca-mcp-demo-mcp-mx01.yellowgrass-7d797e98.eastus2.azurecontainerapps.io"

async def main():
  async with streamablehttp_client(MCP_SERVER_URL) as (
     read_stream,
     write_stream,
     _
  ):
     async with ClientSession(read_stream, write_stream) as session:
      await session.initialize()
      tool_result = await session.call_tool("GetCountries", {})
      
      outer = json.loads(tool_result.content[0].model_dump_json())
      # The outer object contains a "text" field which is a JSON string
      # Then parse the inner "text" field which is a JSON string
      countries = json.loads(outer["text"])

      for country in countries:
          print(country)
          
import asyncio
if __name__ == "__main__":
    asyncio.run(main())