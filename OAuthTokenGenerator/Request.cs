namespace OAuthTokenGeneratorSolution
{
    public class Request
    {
        public string Url { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string GrantType { get; set; }
        public string? Resource { get; set; }
        public string? Scope { get; set; }
        public string? Audience { get; set; }
    }
}
