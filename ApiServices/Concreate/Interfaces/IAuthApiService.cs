using System.Threading.Tasks;
using FurkanBlogProjectFrontEnd.Models;

namespace FurkanBlogProjectFrontEnd.ApiServices.Interfaces
{
    public interface IAuthApiService
    {
        Task<bool> SignIn(AppUserLoginModel appUserLoginModel);
    }
}