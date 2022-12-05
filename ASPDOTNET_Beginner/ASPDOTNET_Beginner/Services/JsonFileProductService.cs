using ASPDOTNET_Beginner.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
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
    }
}
