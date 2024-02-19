namespace RestApiBlazor.IntificationModel
{
    public class LoginResultModel
    {
        public string? Message { get; set; }
        public string? Email { get; set; }
        public string? JwtBearer { get; set; }
        public bool Success { get; set; }
    }
}