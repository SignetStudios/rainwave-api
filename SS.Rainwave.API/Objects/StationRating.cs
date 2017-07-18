using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{
	public class StationRating
	{
		[JsonProperty(PropertyName = "average_rating")]
		public string AverageRating { get; set; }

		[JsonProperty(PropertyName = "ratings")]
		public int Ratings { get; set; }

		[JsonProperty(PropertyName = "sid")]
		public SiteId Sid { get; set; }
	}
}