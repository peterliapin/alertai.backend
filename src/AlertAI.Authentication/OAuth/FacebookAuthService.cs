using System;
using System.Threading.Tasks;

namespace AlertAI.Authentication.OAuth
{
    public class FacebookAuthService : IOAuthService
    {
        public async Task<OAuthToken> AuthenticateAsync(string accessToken)
        {
            // TODO: Implement Facebook authentication logic here
            throw new NotImplementedException();
        }
    }
}