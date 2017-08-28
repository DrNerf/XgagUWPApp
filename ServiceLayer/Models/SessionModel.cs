using Newtonsoft.Json;
using System;

namespace ServiceLayer
{
    internal class SessionModel : ISessionModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }

        [JsonProperty(PropertyName = "sessionToken")]
        public Guid SessionToken { get; set; }
    }
}
