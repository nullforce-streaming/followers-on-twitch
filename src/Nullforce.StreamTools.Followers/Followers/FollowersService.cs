using Flurl;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Nullforce.StreamTools.Followers.Auth;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nullforce.StreamTools.Followers.Followers
{
    public class FollowersService
    {
        private readonly IConfiguration _configuration;
        private readonly TokenProvider _tokenProvider;

        private static readonly string[] Names = new[]
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        public FollowersService(IConfiguration configuration, TokenProvider tokenProvider)
        {
            _configuration = configuration;
            _tokenProvider = tokenProvider;
        }

        public async Task<Followers[]> GetFollowersAsync(string userid)
        {
            var clientid = _configuration["Twitch:ClientId"];
            var token = _tokenProvider.AccessToken;

            var result = await "https://api.twitch.tv/helix/users/follows"
                .SetQueryParam("to_id", userid)
                .SetQueryParam("first", 100)
                .WithHeader("Authorization", $"Bearer {token}")
                .WithHeader("Client-ID", clientid)
                .GetJsonAsync<FollowersWrapper>();

            return result.Followers;
        }
    }
}
