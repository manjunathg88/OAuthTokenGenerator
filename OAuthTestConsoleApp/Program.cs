using OAuthTokenGeneratorSolution;

HttpClient _httpClient = new HttpClient();

var _oAuthTokenGenerator = new OAuthTokenGenerator(_httpClient);

Request oAuthRequest = new Request()
{
    Url = "https://accounts.google.com/o/oauth2/v2/auth",
    ClientId = "8819981768.apps.googleusercontent.com",
    ClientSecret= "<client-secret>"
};

var resp = _oAuthTokenGenerator.GetAuthToken(oAuthRequest);
Console.WriteLine(resp.Result);
