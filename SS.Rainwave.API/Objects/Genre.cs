using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{
	public class Genre
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }
	}
}