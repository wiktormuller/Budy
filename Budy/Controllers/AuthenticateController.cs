using System;
using System.Threading.Tasks;
using Budy.Application.Identity.Commands;
using Budy.Application.Identity.Requests;
using Budy.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Budy.Controllers
{
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public AuthenticateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var command = new LoginCommand(request.Username, request.Password);

            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (UserNotFoundException e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var command = new RegisterCommand(request.Username, request.Email, request.Password);
            
            try
            {
                var response = await _mediator.Send(command);

                if (response.Succeeded)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (UserAlreadyExistsException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("/register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterRequest request)
        {
            var command = new RegisterCommand(request.Username, request.Email, request.Password);
            
            try
            {
                var response = await _mediator.Send(command);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}