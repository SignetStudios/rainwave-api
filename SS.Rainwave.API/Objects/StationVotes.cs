using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{
	public class StationVotes
	{
		[JsonProperty(PropertyName = "votes")]
		public int Votes { get; set; }

		[JsonProperty(PropertyName = "sid")]
		public SiteId Sid { get; set; }
	}
}