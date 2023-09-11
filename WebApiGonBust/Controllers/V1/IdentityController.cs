using Microsoft.AspNetCore.Mvc;
using WebApiGonBust.Contracts.V1;
using WebApiGonBust.Contracts.V1.Requests;
using WebApiGonBust.Contracts.V1.Responses;
using WebApiGonBust.Services;

namespace WebApiGonBust.Controllers.V1
{
    public class IdentityController : Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService) 
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            var authResponse = await _identityService.ResgisterAsync(request.Email, request.Password);

            if (!authResponse.Success) 
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = authResponse.Errors,
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = authResponse.Token,
            });
        }
    }
}
