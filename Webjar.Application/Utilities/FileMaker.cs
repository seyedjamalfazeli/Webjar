using Microsoft.AspNetCore.Http;

namespace Webjar.Application.Utitlies
{
    public class FileMaker
    {
        public static string SaveSingleFile(IFormFile formFile, string folder, string fileName = "")
        {
            try
            {
                if (formFile != null)
                {
                    string[] accessFiles = { "png", "jpeg", "jpg", "jfif", "pjepg","webp"};
                    string avatarFileExtension = Path.GetExtension(formFile.FileName.ToLower());

                    bool isExist = false;

                    for (int i = 0; i < accessFiles.Length; i++)
                    {
                        isExist = avatarFileExtension.Contains(accessFiles[i]);
                        if (isExist)
                            break;
                    }

                    if (!isExist)
                        return null;

                    string folderPath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{folder}");
                    if (!Directory.Exists(folderPath))
                        Directory.CreateDirectory(folderPath);

                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{folder}", fileName);
                    if (File.Exists(imagePath))
                        File.Delete(imagePath);

                    fileName = NameGenerator.GenerateUniqueCode() + Path.GetExtension(formFile.FileName);
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{folder}", fileName);

                    using (var stram = new FileStream(imagePath, FileMode.Create))
                    {
                        formFile.CopyTo(stram);
                    }

                }

                return fileName;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
