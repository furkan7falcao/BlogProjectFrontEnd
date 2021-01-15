using System.Threading.Tasks;

namespace FurkanBlogProjectFrontEnd.ApiServices.Interfaces
{
    public interface IImageApiService
    {
         Task<string> GetBlogImageByIdAsync(int id);
    }





}