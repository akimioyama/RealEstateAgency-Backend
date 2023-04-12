using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace RealEstateAgency.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;
        public ImageController (IWebHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        [HttpGet]
        public VirtualFileResult GetImg(string name)
        {
            return File(name, "image/jpeg");
        }
        [HttpPost("{id_user}")]
        public async Task<IActionResult> Upload(IFormFile[] files, int id_user)
        {
            if (files == null || files.Length == 0)
            {
                return BadRequest("Please select one or more files to upload.");
            }
            int i = 0;
            foreach (var file in files)
            {
                if (file == null || file.Length == 0)
                {
                    continue;
                }
                i++;
                string fileName = Path.GetFileName("item" + id_user + "_" + i + ".jpg" );
                string filePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return Ok($"Files uploaded successfully: {string.Join(",", files.Select(f => f.FileName))}");
        }
    }
}
