using System.IdentityModel.Tokens.Jwt;

namespace OAuthTokenGeneratorSolution
{
    public class OAuthTokenGenerator
    {
        private readonly HttpClient _httpClient;

        public OAuthTokenGenerator(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpContent?> GetAuthToken(Request oAuthRequest)
        {
            var payload = new Dictionary<string, string>
            {
                { "client_id", oAuthRequest.ClientId },
                { "client_secret", oAuthRequest.ClientSecret },
                { "grant_type", oAuthRequest.GrantType }
            };

            if (!string.IsNullOrEmpty(oAuthRequest.Scope))
            {
                payload.Add("scope", oAuthRequest.Scope);
            }

            if (!string.IsNullOrEmpty(oAuthRequest.Resource))
            {
                payload.Add("resource", oAuthRequest.Resource);
            }

            var request = new HttpRequestMessage(HttpMethod.Post, oAuthRequest.Url)
            {
                Content = new FormUrlEncodedContent(payload)
            };

            var response = await _httpClient.SendAsync(request);

            return response.Content;
        }

        public bool CheckTokenStatus(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var authTokenJWT = handler.ReadJwtToken(accessToken);
            return authTokenJWT?.ValidTo < DateTime.UtcNow;
        }
    }
}