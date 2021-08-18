using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using CP380_B1_BlockList.Models;
using System.Net.Http.Json;

namespace CP380_B3_BlockBlazor.Data
{
    public class PendingTransactionService
    {
        private readonly HttpClient client;
        private readonly IConfiguration configuration;

        // TODO: Add variables for the dependency-injected resources
        //       - httpClient
        //       - configuration
        //
        public PendingTransactionService(HttpClient Client, IConfiguration configuration)
        {
            client = Client;
            this.configuration = configuration;
        }
        //
        // TODO: Add a constructor with IConfiguration and IHttpClientFactory arguments
        //

        //
        // TODO: Add an async method that returns an IEnumerable<Payload> (list of Payloads)
        //       from the web service
        //
        public async Task<List<Payload>> GetPayloads(){

            return await client.GetFromJsonAsync<List<Payload>>(configuration["PayloadService:url"]);
        }
        //
        // TODO: Add an async method that returns an HttpResponseMessage
        //       and accepts a Payload object.
        //       This method should POST the Payload to the web API server
        //
        public async Task<string> AddPayload(Payload payload)
        {
            string mass = "";
             var resmassage=  await client.PostAsJsonAsync(configuration["PayloadService:url"], payload);
            if (resmassage.IsSuccessStatusCode)
            {
                mass = resmassage.StatusCode.ToString();
            }
            else
            {
                 mass = "Error to adding Payload";
            }
            return mass;
        }

    }
}
