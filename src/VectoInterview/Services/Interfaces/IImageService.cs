using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using VectoInterview.Models.Requests;

namespace VectoInterview.Services.Interfaces
{
    public interface IImageService
    {
        Task<Guid> UploadImageAsync(IFormFile file);

        void DeleteImage(Guid id);

        Task<byte[]> BeautifyAsync(BeautifyImagesRequest request);
    }
}