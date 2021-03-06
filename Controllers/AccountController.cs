using System.Threading.Tasks;
using FurkanBlogProjectFrontEnd.ApiServices.Interfaces;
using FurkanBlogProjectFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FurkanBlogProjectFrontEnd.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthApiService _authApiService;
        public AccountController(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(AppUserLoginModel appUserLoginModel )
        {
            if(await _authApiService.SignIn(appUserLoginModel))
            {
                return RedirectToAction("test");
            }

            return View();
        }

    }
}