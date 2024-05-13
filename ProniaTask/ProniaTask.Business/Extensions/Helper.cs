using Microsoft.AspNetCore.Http;
using ProniaTask.Business.Exceptions;
using ProniaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaTask.Business.Extensions;

public static class Helper
{
    public static string SaveFile(string rootPath,string folder,IFormFile file) 
    {
        if (file.ContentType != "image/png" && file.ContentType != "image/jpeg")
            throw new ImageContentTypeException("Fayl formati duzgun deyil!");
        if (file.Length > 2097152)
            throw new ImageSizeException("Sheklin olcusu max 2mb ola biler");

        var extension = Path.GetExtension(file.FileName);
        var fileName = $"slider-{Guid.NewGuid().ToString().ToLower()}{extension}";

        string path = rootPath+ @$"\{folder}\" + fileName;

         using (FileStream fileStream = new FileStream(path, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        return fileName;
    }

    public static void DeleteFile(string rootPath,string folder,string fileName)
    {
        string path = rootPath + @$"\{folder}\" + fileName;
        if (!File.Exists(path))
            throw new Exceptions.FileNotFoundException("fayl tapilmadi!");

        File.Delete(path);

      
    }

        
}
