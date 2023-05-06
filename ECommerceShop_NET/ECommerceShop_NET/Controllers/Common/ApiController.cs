using ECommerceShop.Contracts.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace ECommerceShop.API.Controllers.Common
{
    [ApiController]
    public class ApiController : ControllerBase
    {

        protected AppResult SuccessfullResult(object? data = null)
        {
            var result = new AppResult { Success = true, Data = data };
            return result;
        }

        protected AppResult UnSuccessfullResult(object? data = null)
        {
            var result = new AppResult { Success = false, Data = data };
            return result;
        }


        protected AppResult SuccessfullMessage(object? data = null)
        {
            var result = new AppResult { Success = true, Data = data };
            result.SetSuccessMessage("عملیات با موفقیت انجام گردید");
            return result;
        }

        protected AppResult ExceptionMessage(System.Exception ex)
        {
            var result = new AppResult
            {
                Success = false
            };

            result.SetDangerMessage("خطا در انجام عملیات " + ex.Message);
            return result;
        }

        protected AppResult ErrorMessage(string message, object? data = null)
        {
            var result = new AppResult { Success = false, Data = data };
            result.SetDangerMessage(message);
            return result;
        }

        protected AppResult ErrorMessage(ModelStateDictionary modelState)
        {
            var errors = modelState.Where(x => x.Value != null && x.Value.Errors.Any())
            .SelectMany(x => x.Value?.Errors.Select(y => y.ErrorMessage) ?? new List<string>())
            .Select(x => new MessageItem { Message = x }).ToArray();

            var result = new AppResult { Success = false };
            result.SetMessage(MessageType.Danger, errors);
            return result;
        }

        protected string GetJwtToken()
        {
            return HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
        }

        protected string GetServerAddress()
        {
            return $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
        }

        protected Dictionary<string, string> GetTokenInfo()
        {
            var tokenClaims = new Dictionary<string, string>();
            string token = GetJwtToken();

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var claims = jwtSecurityToken.Claims.ToList();

            foreach (var claim in claims)
            {
                tokenClaims.Add(claim.Type, claim.Value);
            }
            return tokenClaims;
        }

        public int UserId
        {
            get
            {
                return int.Parse(GetTokenInfo()["sub"]);
            }
        }
    }
}
