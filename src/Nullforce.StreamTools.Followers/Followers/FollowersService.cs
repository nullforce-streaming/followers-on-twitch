using System;
using System.Linq;
using System.Threading.Tasks;

namespace Nullforce.StreamTools.Followers.Followers
{
    public class FollowersService
    {
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

        public Task<Followers[]> GetFollowersAsync()
        {
            var rng = new Random();
            var today = DateTime.Today;

            return Task.FromResult(Enumerable.Range(1, 100).Select(index => new Followers
            {
                Followed = today.AddDays(-index),
                Name = Names[rng.Next(Names.Length)] + Names[rng.Next(Names.Length)] + Names[rng.Next(Names.Length)],
            }).ToArray());
        }
    }
}
