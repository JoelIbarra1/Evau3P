using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evau3P.MVVM.Models;
using Newtonsoft.Json;
using SQLite;
using Evau3P.MVVM.Models;

namespace Evau3P.Services
{
    public class APIservice
    {
        private readonly HttpClient _httpClient;

        public APIservice()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Jokes> GetSWCharactersAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://api.chucknorris.io/jokes/random");
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);
            return apiResponse?.Result;
        }

        private class ApiResponse
        {
            [JsonProperty("result")]
            public Jokes Result { get; set; }

        }
    }
}

