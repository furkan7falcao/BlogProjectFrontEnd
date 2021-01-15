using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FurkanBlogProjectFrontEnd.ApiServices.Interfaces;
using FurkanBlogProjectFrontEnd.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FurkanBlogProjectFrontEnd.ApiServices.Concreate
{
    public class AuthApiManager : IAuthApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor; 
        public AuthApiManager(HttpClient httpClient,IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress=new Uri("http://localhost:49614/api/auth/");
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> SignIn(AppUserLoginModel appUserLoginModel)
        {
            var jsonData = JsonConvert.SerializeObject(appUserLoginModel);

            var content = new StringContent(jsonData,Encoding.UTF8,"application/json");

            var responseMessage = await _httpClient.PostAsync("SignIn",content);

            if(responseMessage.IsSuccessStatusCode)
            {
                var accessToken = JsonConvert.DeserializeObject<AccessToken>(await responseMessage.Content.ReadAsStringAsync());

                _httpContextAccessor.HttpContext.Session.SetString("token",accessToken.Token);

                return true;
            }

            return false;
        }



    }


}