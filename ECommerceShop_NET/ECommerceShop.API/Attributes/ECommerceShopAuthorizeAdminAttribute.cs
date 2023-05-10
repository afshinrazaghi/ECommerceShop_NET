using ECommerceShop.Application.Features.Users.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace ECommerceShop.API.Attributes
{
    public class ECommerceShopAuthorizeAdminAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _sender = context.HttpContext.RequestServices.GetRequiredService<ISender>();
            var user = context.HttpContext.User;

            if (!user?.Identity?.IsAuthenticated ?? false)
            {
                // it isn't needed to set unauthorized result 
                // as the base class already requires the user to be authenticated
                // this also makes redirect to a login page work properly
                // context.Result = new UnauthorizedResult();
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Unauthorized);
                return;
            }

            var token = GetJwtToken(context);
            var userId = GetTokenInfo(context)["sub"];
            bool isAuthorized = true;
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(userId))
            {
                isAuthorized = false;
            }
            else
            {
                var queryCheckUserToken = new CheckUserTokenQuery()
                {
                    AccessToken = token,
                    UserId = Guid.Parse(userId)
                };

                var res = _sender.Send(queryCheckUserToken).Result;
                if (!res)
                    isAuthorized = false;

                if (isAuthorized)
                {
                    var queryCheckIsAdmin = new CheckIsAdminQuery()
                    {
                        UserId = Guid.Parse(userId)
                    };
                    var res2 = _sender.Send(queryCheckIsAdmin).Result;
                    if (!res2)
                        context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                }
            }
        }

        private Dictionary<string, string> GetTokenInfo(AuthorizationFilterContext context)
        {
            var tokenClaims = new Dictionary<string, string>();
            string token = GetJwtToken(context);

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var claims = jwtSecurityToken.Claims.ToList();

            foreach (var claim in claims)
            {
                tokenClaims.Add(claim.Type, claim.Value);
            }
            return tokenClaims;
        }

        private string GetJwtToken(AuthorizationFilterContext context)
        {
            return context.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
        }
    }


}
