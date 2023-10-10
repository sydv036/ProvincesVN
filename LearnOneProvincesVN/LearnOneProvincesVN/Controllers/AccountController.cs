using LearnOneProvincesVN.Api.BaseResponse;
using LearnOneProvincesVN.Domain.Request;
using LearnOneProvincesVN.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LearnOneProvincesVN.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        private BaseResponse<object> TemplateReponse(HttpStatusCode httpStatusCode, HttpStatusCode error, string message, object ojb)
        {
            return new BaseResponse<object>(httpStatusCode, message, error, ojb);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register model)
        {
            var check = await _accountService.Register(model);
            if (check)
            {
                return Ok(TemplateReponse(HttpStatusCode.OK, 0, "SuccessFully", model));
            }
            return BadRequest(TemplateReponse(HttpStatusCode.BadRequest, HttpStatusCode.NotAcceptable, "Create Account Fail", model));
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignIn model)
        {
            var result = await _accountService.Signin(model);
            if (result != null)
            {
                return Ok(TemplateReponse(HttpStatusCode.OK, 0, "Successfully", result));
            }
            return NotFound(TemplateReponse(HttpStatusCode.ProxyAuthenticationRequired, HttpStatusCode.ProxyAuthenticationRequired, "Not Found", null));
        }
    }
}
