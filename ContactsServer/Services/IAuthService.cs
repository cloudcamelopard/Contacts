using ContactsServer.Models;

namespace ContactsServer.Services
{
    public interface IAuthService
    {
        bool VerifyPassword(string password, string storedHash, string storedSalt);
        (string hash, string salt) GetSaltAndHash(string password, int size = 64);

        string GenerateJWTToken(User user);
    }
}
