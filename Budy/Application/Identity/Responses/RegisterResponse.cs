namespace Budy.Application.Identity.Responses
{
    public class RegisterResponse
    {
        public string Message { get; private set; }
        public bool Succeeded { get; private set; }
        
        public RegisterResponse(string message, bool succeeded)
        {
            Message = message;
            Succeeded = succeeded;
        }
    }
}