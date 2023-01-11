using ASPDOTNET_Beginner.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace ASPDOTNET_Beginner.Services {
    public class JsonFileProductService {
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment) {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }   //WebHostEnvironment를 통해 경로를 알 수 있다.
        }

        public IEnumerable<Product> GetProducts() {
            using (var jsonFileReader = File.OpenText(JsonFileName)) {

                return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),        //JSON파일로부터 객체를 가져와 우리가 원하는 데이터형태로 변형(역직렬화) => Product.cs 모양
                    new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }
        public void AddRating(string productId, int rating) {
            var products = GetProducts();

            //LINQ
            var query = products.First(x => x.Id == productId);

            if (query.Ratings == null) {
                query.Ratings = new int[] { rating };
            }
            else {
                var ratings = query.Ratings.ToList();
                ratings.Add(rating);
                query.Ratings = ratings.ToArray();
            }
            using (var outputStream = File.OpenWrite(JsonFileName)) {
                JsonSerializer.Serialize<IEnumerable<Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products    
                );
            }
        }
    }
}
