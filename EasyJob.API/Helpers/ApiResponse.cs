namespace EasyJob.API.Helpers
{
    public class ApiResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }

        public ApiResponse()
        {
            
        }
        public ApiResponse(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }
    }
}