using CloudPOSAPI.Models;

namespace CloudPOSAPI.Services
{
    public interface ITokenServices
    {
        UserModel Authenticate(UserModel user);
        TokenModel GenerateToken(UserModel user);

    }
}
