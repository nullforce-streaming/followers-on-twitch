using Newtonsoft.Json;
using System;

namespace Nullforce.StreamTools.Followers.Followers
{
    public class Followers
    {
        [JsonProperty("followed_at")]
        public DateTime Followed { get; set; }
        [JsonProperty("from_name")]
        public string Name { get; set; }
    }

    public class FollowersWrapper
    {
        public int Total { get; set; }
        [JsonProperty("data")]
        public Followers[] Followers { get; set; }
        public Pagination Pagination { get; set; }
    }

    public class Pagination
    {
        public string Cursor { get; set; }
    }
}
