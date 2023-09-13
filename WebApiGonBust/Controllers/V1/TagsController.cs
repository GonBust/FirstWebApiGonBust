using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiGonBust.Contracts.V1;
using WebApiGonBust.Services;

namespace WebApiGonBust.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class TagsController : Controller
    {
        private readonly IForecastService _forecastService;

        public TagsController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet(ApiRoutes.Tags.GetAll)]
        [Authorize(Policy = "TagViewer")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _forecastService.GetTagsAsync());
        }
    }
}
