namespace Assignment.API.Responses
{
    public class TokenResponse : BaseResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string user { get; set; }
        public int userId { get; set; }
    }
}
