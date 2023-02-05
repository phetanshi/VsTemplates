namespace PsTest.Api.Util
{
    public class ApiResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public object? Payload { get; set; }
    }
}
