using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MyProfessor.Helpers
{
    public interface IImageHandler
    {
        Task<string> UploadImage(IFormFile file);
    }
}
