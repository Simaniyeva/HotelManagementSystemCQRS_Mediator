namespace HotelAPI.Application.Helpers
{
    public static class FileHelper 
    {
        public static string SavePhotoToFtp(byte[] imageBytes, string name)
        {
            try
            {
                string folderPath = FileServerPath.Path;
                string guid = Guid.NewGuid().ToString();
                string fileName = $"{name}{guid}.jpeg";
                string filePath = $"{folderPath}/{fileName}";
                File.WriteAllBytes(filePath, imageBytes);
                return fileName;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return null;
            }
        }

        
        private static string GetFileType(FileType fileExtension)
        {
            switch (fileExtension)
            {
                case FileType.JPEG:
                    fileExtension = FileType.JPEG;
                    break;
                case FileType.DOCX:
                    fileExtension = FileType.DOCX;
                    break;
                case FileType.PDF:
                    fileExtension = FileType.PDF;
                    break;
            }

            return fileExtension.ToString();
        }
        public static byte[] GetPhoto(string fileNameFromDb)
        {
            byte[] photo = null;
            try
            {
                if (!string.IsNullOrEmpty(fileNameFromDb))
                {
                    string folderPath = FileServerPath.Path; //WebConfigurationManager.AppSettings["PhPersonPhotoPath"];
                    string fullFilePath = Path.Combine(folderPath, fileNameFromDb.ToUpper());
                    photo = File.ReadAllBytes(fullFilePath);
                }
                return photo;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                return photo;
            }
        }
    }
}
