﻿using RestSharp;
using Newtonsoft.Json.Linq;
using BooksManagementApi.Models;

namespace BooksManagementApi.Services
{
    public class ImaggaService
    {
        public async Task<List<ImaggaTag>> GetTags(string imageUrl)
        {
            var client = new RestClient("https://api.imagga.com/v2/");
            var request = new RestRequest("tags", Method.Get);
            request.AddParameter("image_url", imageUrl);

            var credentials = "acc_c61058d2a32b21c:dffc59bad8bfc207642b3a97bba7b7ff";
            request.AddHeader("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(credentials)));
               
            RestResponse response = await client.ExecuteAsync(request);
            JObject jsonResponse = JObject.Parse(response.Content ?? string.Empty);
            JArray? tagsArray = jsonResponse["result"]?["tags"] as JArray;

            var tags = new List<ImaggaTag>();
            if (tagsArray != null)
            {
                foreach (JObject tagObject in tagsArray)
                {
                    tags.Add(new ImaggaTag
                    {
                        Tag = (string?)(tagObject["tag"]?["en"]),
                        Confidence = (double)(tagObject["confidence"] ?? 0.0)
                    });
                }
            }
            return tags;
        }
    }
}

