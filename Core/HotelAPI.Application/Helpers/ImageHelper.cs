using Microsoft.AspNetCore.Http;

namespace HotelAPI.Application.Helpers
{
    public class ImageHelper
    {
        public static string Upload(IFormFile file)
        {
            string sourcePath = Path.GetTempFileName();

            if (file != null)
            {
                using var upload = new FileStream(sourcePath, FileMode.Create);
                file.CopyTo(upload);
            }
            string filepath = FilePath(file);
            File.Move(sourcePath, filepath);
            return filepath;

        }
        public static void Delete(string path)
        {
            File.Delete(path);
        }
        public static string Update(string sourcePath, IFormFile file)
        {
            string result = FilePath(file);
            if (sourcePath.Length != 0)
            {
                using (var upload = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(upload);
                }
            }
            File.Delete(sourcePath);
            return result;
        }
        public static string FilePath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            string path = Environment.CurrentDirectory + @"\images\user-images";
            string newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }

}

