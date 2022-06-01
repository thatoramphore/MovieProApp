//transforming image formats suitable for displaying and storage
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieProApp.Services.Interfaces
{
    public interface IImageService
    {
        //convert user-selected image into byte array
        Task<byte[]> EncodeImageAsync(IFormFile poster);
        //turining imageURL into a byte array for storage
        Task<byte[]> EncodeImageURLAsync(string imageURL);
        //display image
        string DecodeImage(byte[] poster, string contentType);
    }
}
