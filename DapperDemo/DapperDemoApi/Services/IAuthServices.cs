using DapperDemoData.Models;

namespace DapperDemoApi.Services
{
    public interface IAuthService
    {
        Person AuthenticateUser(string name, string email);
        string GenerateToken(Person user);
    }
}
