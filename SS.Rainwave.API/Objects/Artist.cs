using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{
	[JsonObject]
	public class Artist
	{
		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "name_searchable")]
		public string NameSearchable { get; set; }
	}
}