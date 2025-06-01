using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace azure_gallery;

public class Function1
{
    private readonly ILogger<Function1> _logger;

    public Function1(ILogger<Function1> logger)
    {
        _logger = logger;
    }

    [Function("GetGalleries")]
    public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
    {
        _logger.LogInformation("Returning list of galleries.");

        var galleries = new List<Gallery>
        {
            new Gallery 
            { 
                Id = 1, 
                Title = "Sunset Bliss", 
                Category = "Nature", 
                Date = "2024-10-10", 
                Color = "#FF5733",
                Url = "https://picsum.photos/200"
            },
            new Gallery 
            { 
                Id = 2, 
                Title = "Urban Night", 
                Category = "City", 
                Date = "2024-11-01", 
                Color = "#1C1C1C",
                Url = "https://picsum.photos/200"
            },
            new Gallery 
            { 
                Id = 3, 
                Title = "Pastel Dreams", 
                Category = "Abstract", 
                Date = "2025-01-15", 
                Color = "#E6B0AA",
                Url = "https://picsum.photos/200"
            }
        };

        var response = req.CreateResponse(System.Net.HttpStatusCode.OK);
        response.WriteAsJsonAsync(galleries);

        return response;
    }

    public class Gallery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }  // ISO 8601 format
        public string Color { get; set; } // Hex color code
        public string Url { get; set; }   // Link to the gallery
    }
}
