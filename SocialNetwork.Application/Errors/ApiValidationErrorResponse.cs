namespace SocialNetwork.Application.Errors
{
    public class ApiValidationErrorResponse : ApiErrorResponse
    {
        public List<string> Errors { get; set; } = new List<string>();
        public ApiValidationErrorResponse() : base(400)
        {
        }
    }
}
