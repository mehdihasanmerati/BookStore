using Microsoft.AspNetCore.Http;

namespace BookStore.BusinessLogic.Frameworks
{
    public interface IFileService
    {
        Task<string> SaveImageAsync(IFormFile imageFile);
    }

    public class FileService : IFileService
    {
        public async Task<string> SaveImageAsync(IFormFile imageFile)
        {
            if (imageFile == null)
                return null;

            var filePath = Path.Combine("wwwroot/images", imageFile.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return "/images/" + imageFile.FileName;
        }
    }

}
