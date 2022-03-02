using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VectoInterview.Models.Requests;
using VectoInterview.Services.Interfaces;

namespace VectoInterview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPut]
        public async Task<Guid> Upload(IFormFile file) => await _imageService.UploadImageAsync(file);

        [HttpDelete("{id}")]
        public void Delete([FromRoute] Guid id) => _imageService.DeleteImage(id);

        [HttpPost]
        public async Task<byte[]> Beautify([FromBody] BeautifyImagesRequest request) => await _imageService.BeautifyAsync(request);
    }
}