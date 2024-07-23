using LMProject.Models;

namespace LMProject.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
