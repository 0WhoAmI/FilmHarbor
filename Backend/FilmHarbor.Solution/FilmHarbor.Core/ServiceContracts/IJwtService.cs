using FilmHarbor.Core.DTO;
using FilmHarbor.Core.Entities;

namespace FilmHarbor.Core.ServiceContracts
{
    public interface IJwtService
    {
        AuthenticationResponse CreateJwtToken(User user);
    }
}
