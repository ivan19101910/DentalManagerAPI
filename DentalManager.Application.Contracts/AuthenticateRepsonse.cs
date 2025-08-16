namespace DentalManagerAPI.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(Worker worker, string token)
        {
            Id = worker.Id;
            FirstName = worker.FirstName;
            LastName = worker.LastName;
            Login = worker.Email;
            Token = token;
        }
    }
}
