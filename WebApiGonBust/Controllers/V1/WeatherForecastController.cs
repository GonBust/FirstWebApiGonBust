using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApiGonBust.Contracts.V1;
using WebApiGonBust.Contracts.V1.Requests;
using WebApiGonBust.Contracts.V1.Responses;
using WebApiGonBust.Domain;
using WebApiGonBust.Extensions;
using WebApiGonBust.Services;

namespace WebApiGonBust.Controllers.V1
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IForecastService _forecastService;

        public WeatherForecastController(IForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [HttpGet(ApiRoutes.Forecasts.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _forecastService.GetForecastsAsync());
        }

        [HttpGet(ApiRoutes.Forecasts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid forecastId)
        {
            var forecast = await _forecastService.GetForecastByIdAsync(forecastId);

            if (forecast == null)
                return NotFound();

            return Ok(forecast);
        }

        [HttpPut(ApiRoutes.Forecasts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid forecastId, [FromBody] UpdateForecastRequest request)
        {
            var userOwnsForecast = await _forecastService.UserOwnsForecastAsync(forecastId, HttpContext.GetUserId());

            if (!userOwnsForecast)
                return BadRequest(new { Error = "You do not Own this post" });

            var forecast = await _forecastService.GetForecastByIdAsync(forecastId);
            forecast.Date = request.Date;

            var updated = await _forecastService.UpdateForecastAsync(forecast);

            if(updated)
                return Ok(forecast);

            return NotFound();
        }

        [HttpPost(ApiRoutes.Forecasts.Create)]
        public async Task<IActionResult> Create([FromBody] CreateForecastRequest forecastRequest)
        {
            var weatherForecast = new WeatherForecast 
            { 
                Date = forecastRequest.Date,
                UserId = HttpContext.GetUserId()
            };

            await _forecastService.CreateForecastAsync(weatherForecast);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = $"{baseUrl}/{ApiRoutes.Forecasts.Get.Replace("{forecastId}", weatherForecast.Id.ToString())}";

            var response = new ForecastResponse { Id = weatherForecast.Id };
            return Created(locationUri, response);
        }

        [HttpDelete(ApiRoutes.Forecasts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid forecastId)
        {
            var userOwnsForecast = await _forecastService.UserOwnsForecastAsync(forecastId, HttpContext.GetUserId());

            if (!userOwnsForecast)
                return BadRequest(new { Error = "You do not Own this post" });

            var deleted = await _forecastService.DeleteForecastAsync(forecastId);

            if (deleted)
                return NoContent();

            return NotFound();
        }
    }
}