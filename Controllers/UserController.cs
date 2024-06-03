using IdentityStudy.Application.DTOs.Request;
using IdentityStudy.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace IdentityStudy.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController : ControllerBase
{
        readonly IIdentityService _identityService;

        public UserController(IIdentityService identityService) =>
            _identityService = identityService;

        [HttpPost("cadastro")]
        public async Task<IActionResult> Register(UserRegistrationRequest userRegistrationRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var resultado = await _identityService.UserRegistration(userRegistrationRequest);
            if (resultado.Success)
                return Ok(resultado);
            //else if (resultado.Errors.Count > 0)
            //{
            //    var problemDetails = new CustomProblemDetails(HttpStatusCode.BadRequest, Request, errors: resultado.Erros);
            //    return BadRequest(problemDetails);
            //}

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

