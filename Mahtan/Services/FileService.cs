﻿using Mahtan.Assets.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Mahtan.Services
{
    public interface IFileService
    {
        Task<string> UploadAsync(IFormFile file, string pathToSave, string preFileToRemove = null, string defaultFileNameToPreventRemove = null);
    }

    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadAsync(IFormFile file, string pathToSave, string preFileToRemove = null, string defaultFileNameToPreventRemove = null)
        {
            try
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
                var fileToCreateFullPath = Path.Combine(_webHostEnvironment.WebRootPath, pathToSave, fileName);

                using (var fileStream = new FileStream(fileToCreateFullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                if (!preFileToRemove.IsNullOrWhitespace() && preFileToRemove != defaultFileNameToPreventRemove)
                    try
                    {
                        var fileToRemoveFullPath = Path.Combine(_webHostEnvironment.WebRootPath, pathToSave, preFileToRemove);
                        File.Delete(fileToRemoveFullPath);
                    }
                    catch { }

                return fileName;
            }
            catch
            {
                return "";
            }
        }
    }
}
