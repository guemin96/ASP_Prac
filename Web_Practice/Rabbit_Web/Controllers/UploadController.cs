using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace Rabbit_Web.Controllers
{
    public class UploadController : Controller
    {
        [System.Obsolete]
        private readonly IHostingEnvironment _environment;

        [System.Obsolete] // Obsolete : 구식(더 이상 쓸모없는)
        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        //http://www.example.com/Upload/ImageUpload
        [HttpPost, Route("api/upload")]
        [System.Obsolete]
        public IActionResult ImageUpload(IFormFile file)    //input text에서 전송을 눌렀을때 그 파일자체가 이 함수 파라미터로 옴  asp.net core에만 존재
        {
            //# 이미지나 파일을 업로드 할 때 필요한 구성
            //1. Path(경로) - 어디에다 저장할지 결정
            var path = Path.Combine(_environment.WebRootPath,@"images\upload");
            //2. Name(파일이름) - 기본 틀(DateTime, GUID, +GUID)
            //3. Extension(확장자) - jpg,png,..txt
            var fileName = file.FileName;

            using (var fileStream = new FileStream(Path.Combine(path,fileName),FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return Ok(new {file ="/images/upload/"+fileName,success = true });
            //16강 33분

            //#URL 접근 방식
            //ASP.NET - 호스트명/+api/upload
            //JavaScript - 호스트명 + api/upload => http://www.example.comapi/upload
            //JavaScript - 호스트명 + api/upload => http://www.example.comapi/upload
        }
    }
}
