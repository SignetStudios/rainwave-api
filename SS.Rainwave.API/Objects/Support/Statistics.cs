using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects.Support
{
	[JsonObject]
	public class RequestCount
	{
		[JsonProperty(PropertyName = "requests")]
		public int Requests { get; set; }

		[JsonProperty(PropertyName = "sid")]
		public SiteId Sid { get; set; }
	}

	public class  RatingCount
	{
		[JsonProperty(PropertyName = "ratings")]
		public int Ratings { get; set; }

		[JsonProperty(PropertyName = "rating")]
		public decimal Rating { get; set; }
	}

	public class StationRating
	{
		[JsonProperty(PropertyName = "average_rating")]
		public string AverageRating { get; set; }

		[JsonProperty(PropertyName = "ratings")]
		public int Ratings { get; set; }

		[JsonProperty(PropertyName = "sid")]
		public SiteId Sid { get; set; }
	}

	public class StationVotes
	{
		[JsonProperty(PropertyName = "votes")]
		public int Votes { get; set; }

		[JsonProperty(PropertyName = "sid")]
		public SiteId Sid { get; set; }
	}
}
