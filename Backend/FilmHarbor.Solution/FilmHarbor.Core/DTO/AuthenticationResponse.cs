namespace FilmHarbor.Core.DTO
{
    public class AuthenticationResponse
    {
        public int Id { get; set; }
        public string? PersonName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}
