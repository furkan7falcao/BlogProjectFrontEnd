using System.Threading.Tasks;
using FurkanBlogProjectFrontEnd.ApiServices.Interfaces;
using FurkanBlogProjectFrontEnd.Enums;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FurkanBlogProjectFrontEnd.TagHelpers
{
    [HtmlTargetElement("getblogimage")]
    public class ImageTagHelper : TagHelper
    {
        private readonly IImageApiService _imageApiService;
        public int Id { get; set; }
        public BlogImageType blogImageType { get; set; } = BlogImageType.BlogHome;

        public ImageTagHelper(IImageApiService imageApiService)
        {
            _imageApiService = imageApiService;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var blob = await _imageApiService.GetBlogImageByIdAsync(Id);

            string html = string.Empty;

            if(blogImageType == BlogImageType.BlogHome)
            {
                html = $"<img src='{blob}' class='card-img-top'/>";
            }

            else
            {
                html = $"<img src='{blob}' class='img-fluid rounded'/>";
            }
            

            output.Content.SetHtmlContent(html);

        }


    }
}