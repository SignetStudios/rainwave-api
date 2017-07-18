using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{
	public class  RatingCount
	{
		[JsonProperty(PropertyName = "ratings")]
		public int Ratings { get; set; }

		[JsonProperty(PropertyName = "rating")]
		public decimal Rating { get; set; }
	}
}