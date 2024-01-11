using OAuthTokenGeneratorSolution;

HttpClient _httpClient = new HttpClient();

var _oAuthTokenGenerator = new OAuthTokenGenerator(_httpClient);

Request oAuthRequest = new Request()
{
    Url = "https://accounts.google.com/o/oauth2/v2/auth",
    ClientId = "8819981768.apps.googleusercontent.com",
    ClientSecret = "<client-secret>"
};

var response = _oAuthTokenGenerator.GetAuthToken(oAuthRequest);
Console.WriteLine(response.Result);

var tokenStatus = _oAuthTokenGenerator.CheckTokenStatus("<token>");
Console.WriteLine(tokenStatus ? "Token is valid" : "Token is valid");


