using ECommerce.Dto.IdentityServerDto;
using ECommerce.WebUI.Settings;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;

namespace ECommerce.WebUI.Services
{
    public class IdentityServerServices : IIdentityServerServices
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ClientSettings _clientSettings;

        public IdentityServerServices(HttpClient httpClient, IHttpContextAccessor contextAccessor, IOptions<ClientSettings> clientSettings)
        {
            _httpClient = httpClient;
            _contextAccessor = contextAccessor;
            _clientSettings = clientSettings.Value;
        }

        public async Task<bool> SignIn(SingInDto singInDto)
        {
            var discoveryendpoints = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = "https://localhost:5001",
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            var passwordTokenReques = new PasswordTokenRequest
            {
                ClientId = _clientSettings.ECommerceManagerClient.ClientId,
                ClientSecret = _clientSettings.ECommerceManagerClient.ClientSecret,
                UserName = singInDto.Username,
                Password = singInDto.Password,
                Address = discoveryendpoints.TokenEndpoint

            };

            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenReques);

            var userinfo = new UserInfoRequest
            {
                Token = token.AccessToken,
                Address = discoveryendpoints.UserInfoEndpoint,

            };

            var userinfos = await _httpClient.GetUserInfoAsync(userinfo);

            ClaimsIdentity ıdentity = new ClaimsIdentity(userinfos.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(ıdentity);

            var authenticationproperties = new AuthenticationProperties();

            authenticationproperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },

                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },

                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString()
                }
            });


            authenticationproperties.IsPersistent = true;

            await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationproperties);

            return true;

        }

    }
}
