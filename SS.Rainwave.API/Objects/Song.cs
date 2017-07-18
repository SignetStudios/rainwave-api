using System.Collections.Generic;
using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{

	[JsonObject]
	public class Song
	{
		[JsonProperty(PropertyName = "albums")]
		public List<Album> Albums { get; set; }

		[JsonProperty(PropertyName = "artist_parseable")]
		public string ArtistParseable { get; set; }

		[JsonProperty(PropertyName = "artists")]
		public List<Artist> Artists { get; set; }

		[JsonProperty(PropertyName = "cool")]
		public bool Cool { get; set; }

		[JsonProperty(PropertyName = "cool_end")]
		public int CoolEnd { get; set; }

		[JsonProperty(PropertyName = "disc_number")]
		public int? DiscNumber { get; set; }

		[JsonProperty(PropertyName = "elec_blocked")]
		public bool ElecBlocked { get; set; }

		[JsonProperty(PropertyName = "elec_blocked_by")]
		public string ElecBlockedBy { get; set; }

		[JsonProperty(PropertyName = "elec_request_user_id")]
		public string ElecRequestUserId { get; set; }

		[JsonProperty(PropertyName = "elec_request_username")]
		public string ElecRequestUsername { get; set; }

		[JsonProperty(PropertyName = "entry_id")]
		public int EntryId { get; set; }

		[JsonProperty(PropertyName = "entry_position")]
		public int EntryPosition { get; set; }
		
		[JsonProperty(PropertyName = "entry_type")]
		public int EntryType { get; set; }

		[JsonProperty(PropertyName = "entry_votes")]
		public int EntryVotes { get; set; }

		[JsonProperty(PropertyName = "fave")]
		public bool Fave { get; set; }

		[JsonProperty(PropertyName = "groups")]
		public List<Group> Groups { get; set; }

		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "length")]
		public int Length { get; set; }

		[JsonProperty(PropertyName = "link_text")]
		public string LinkText { get; set; }

		[JsonProperty(PropertyName = "origin_sid")]
		public int OriginSid { get; set; }

		[JsonProperty(PropertyName = "rating")]
		public decimal Rating { get; set; }

		[JsonProperty(PropertyName = "rating_allowed")]
		public bool RatingAllowed { get; set; }

		[JsonProperty(PropertyName = "rating_count")]
		public int RatingCount { get; set; }

		[JsonProperty(PropertyName = "rating_user")]
		public decimal RatingUser { get; set; }

		[JsonProperty(PropertyName = "requestable")]
		public bool Requestable { get; set; }

		[JsonProperty(PropertyName = "request_count")]
		public int RequestCount { get; set; }

		[JsonProperty(PropertyName = "sid")]
		public int Sid { get; set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "track_number")]
		public int? TrackNumber { get; set; }

		[JsonProperty(PropertyName = "url")]
		public string Url { get; set; }

		[JsonProperty(PropertyName = "year")]
		public int? Year { get; set; }
	}
}
