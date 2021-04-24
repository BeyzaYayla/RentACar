using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helper
{
    public class FileHelper
    {
        public static string UploadFile(IFormFile file)
        {
            var result = GenerateUniquePath(file);
            try
            {
                var sourcepath = Path.GetTempFileName();

                if (file.Length > 0)
                {
                    using (var stream = new FileStream(sourcepath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                File.Move(sourcepath, result.newPath);
            }
            catch (Exception exception)
            {

                return exception.Message;
            }

            return result.Path2;
        }

        public static string UpdateFile(string sourcePath, IFormFile file)
        {
            var result = GenerateUniquePath(file);

            try
            {
                //File.Copy(sourcePath,result);

                if (sourcePath.Length > 0)
                {
                    using (var stream = new FileStream(result.newPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                File.Delete(sourcePath);
            }
            catch (Exception excepiton)
            {
                return excepiton.Message;
            }

            return result.Path2;
        }

        public static IResult DeleteFile(string path)
        {
            File.Delete(path);
            return new SuccessResult();
        }

        public static byte[] GetDefaultFile()
        {
            string path = Environment.CurrentDirectory + @"\wwwroot\Images";
            string fileName = "logo.jpg";
            return File.ReadAllBytes(path + fileName);
        }
        private static (string newPath, string Path2) GenerateUniquePath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            var uniqueFilename = Guid.NewGuid().ToString();


            string path = Environment.CurrentDirectory + @"\wwwroot\Images";

            string result = $@"{path}\{uniqueFilename}";

            return (result, $"\\Images\\{uniqueFilename}");

        }
    }
}
