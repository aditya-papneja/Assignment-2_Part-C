using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

using Microsoft.Extensions.Configuration;
using CP380_B1_BlockList.Models;

using CP380_B3_BlockBlazor.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace CP380_B3_BlockBlazor.Data
{
    public class BlockService
    {
        private readonly IConfiguration con;
        private readonly HttpClient client;

        // TODO: Add variables for the dependency-injected resources
        //       - httpClient
        //       - configuration
        //
        public BlockService(IConfiguration con, HttpClient client)
        {
            this.con = con;
            this.client = client;
        }
        //
        // TODO: Add a constructor with IConfiguration and IHttpClientFactory arguments
        //

        public async Task<IEnumerable<BlockSummary>> GetBlocks()
        {
           

            var r= await client.GetFromJsonAsync<List<BlockSummary>>(con["BlockService:url"]);
            return r;
        }
        //
        // TODO: Add an async method that returns an IEnumerable<Block> (list of Blocks)
        //       from the web service
        //
        public async Task<Block> SummitNewBlockAsync(Block block )
        {
         var result= await client.PostAsJsonAsync<Block>(con["BlockService:url"],block);
            if (result.IsSuccessStatusCode)
            {
                return block;
            }
            return null;
        }
    }
}

