using MetroSystem.Data.Enities.MetroStationMod;
using MetroSystem.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MetroSystem.Service.Service
{
    public class GeocodingService : IGeocodingService
    {
        private readonly HttpClient _httpClient;

        public GeocodingService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("MetroSystemApp/1.0 (dovuongquang2403@gmail.com)");
        }

        public async Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address)
        {
            try
            {
                string url = $"https://nominatim.openstreetmap.org/search?format=json&q={Uri.EscapeDataString(address)}";
                Console.WriteLine($"Geocoding URL: {url}");

                var response = await _httpClient.GetStringAsync(url);
                Console.WriteLine($"Geocoding Response: {response}");

                var results = JsonSerializer.Deserialize<List<GeocodingResult>>(response);
                if (results == null || results.Count == 0)
                {
                    throw new Exception("Không tìm thấy tọa độ!");
                }

                // Lọc ra kết quả ở Việt Nam
                var bestMatch = results.FirstOrDefault(r => r.DisplayName.Contains("Việt Nam"));
                if (bestMatch == null)
                {
                    throw new Exception("Không tìm thấy tọa độ phù hợp tại Việt Nam!");
                }

                Console.WriteLine($"Parsed Coordinates: Lat={bestMatch.Latitude}, Lon={bestMatch.Longitude}");
                return (double.Parse(bestMatch.Latitude), double.Parse(bestMatch.Longitude));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Geocoding: {ex.Message}");
                return (0, 0);
            }
        }
    }
   
}
