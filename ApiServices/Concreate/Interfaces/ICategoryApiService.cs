using System.Collections.Generic;
using System.Threading.Tasks;
using FurkanBlogProjectFrontEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace FurkanBlogProjectFrontEnd.ApiServices.Interfaces
{
    public interface ICategoryApiService
    {
        Task<List<CategoryListModel>> GetAllAsync();
        Task<List<CategoryWithBlogsCountModel>> GetAllWithBlogsAsync();
        Task<CategoryListModel> GetByIdAsync(int categoryId);

    }






}