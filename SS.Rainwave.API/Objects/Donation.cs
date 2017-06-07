using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{
	[JsonObject]
	public class Donation
	{
		[JsonProperty(PropertyName = "amount")]
		public decimal Amount { get; set; }

		[JsonProperty(PropertyName = "message")]
		public string Message { get; set; }

		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
	}
}