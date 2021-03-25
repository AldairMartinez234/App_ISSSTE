using App_ISSSTE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App_ISSSTE.Service
{
    internal class ApiService<T>
    {
        public async Task<bool> RegisterUserAsync(string id, string email, string password)
        {
            var Client = new HttpClient();

            var model = new Users
            {
                Id = id,
                Email = email,
                Password = password,
            };

            var json = JsonConvert.SerializeObject(model);

            HttpContent httpContent = new StringContent(json);

            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await Client.PostAsync(Constants.BaseApiAddress + "api/register", httpContent);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;

        }

        public async Task<bool> LoginAsync(string userName, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", userName),
                new KeyValuePair<string, string>("password", password),
            };

            var request = new HttpRequestMessage(
                HttpMethod.Post, Constants.BaseApiAddress + "api/login");

            request.Content = new FormUrlEncodedContent(keyValues);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();


            Debug.WriteLine(content);

            return response.IsSuccessStatusCode;
        }
    }
}
