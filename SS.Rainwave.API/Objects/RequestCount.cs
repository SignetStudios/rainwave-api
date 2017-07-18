using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{
	[JsonObject]
	public class RequestCount
	{
		[JsonProperty(PropertyName = "requests")]
		public int Requests { get; set; }

		[JsonProperty(PropertyName = "sid")]
		public SiteId Sid { get; set; }
	}
}
