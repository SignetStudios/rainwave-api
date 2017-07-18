using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{
	[JsonObject]
	public class User
	{
		[JsonProperty(PropertyName = "admin")]
		public bool Admin { get; set; }

		[JsonProperty(PropertyName = "avatar")]
		public string Avatar { get; set; }

		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "listener_id")]
		public int ListenerId { get; set; }

		[JsonProperty(PropertyName = "listen_key")]
		public string ListenKey { get; set; }

		[JsonProperty(PropertyName = "lock")]
		public bool Lock { get; set; }

		[JsonProperty(PropertyName = "lock_counter")]
		public int LockCounter { get; set; }

		[JsonProperty(PropertyName = "lock_in_effect")]
		public bool LockInEffect { get; set; }

		[JsonProperty(PropertyName = "lock_sid")]
		public SiteId LockSid { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "new_privmsg")]
		public bool NewPrivMsg { get; set; }

		[JsonProperty(PropertyName = "perks")]
		public bool Perks { get; set; }

		[JsonProperty(PropertyName = "rate_anything")]
		public bool RateAnything { get; set; }

		[JsonProperty(PropertyName = "request_expires_at")]
		public int? RequestExpiresAt { get; set; }

		[JsonProperty(PropertyName = "requests_paused")]
		public bool RequestsPaused { get; set; }

		[JsonProperty(PropertyName = "request_position")]
		public int? RequestPosition { get; set; }

		[JsonProperty(PropertyName = "sid")]
		public SiteId Sid { get; set; }

		[JsonProperty(PropertyName = "tuned_in")]
		public bool TunedIn { get; set; }

		[JsonProperty(PropertyName = "voted_entry")]
		public int? VotedEntry { get; set; }


	}
}