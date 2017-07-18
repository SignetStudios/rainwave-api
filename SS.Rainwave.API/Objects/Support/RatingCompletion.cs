using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects.Support
{
	[JsonObject]
	public class RatingCompletion
	{
		[JsonProperty(PropertyName = "1")]
		public int Game { get; set; }
		[JsonProperty(PropertyName = "2")]
		public int OcRemix { get; set; }
		[JsonProperty(PropertyName = "3")]
		public int Covers { get; set; }
		[JsonProperty(PropertyName = "4")]
		public int Chiptunes { get; set; }
	}
}