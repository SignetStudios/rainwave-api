using System.Collections.Generic;
using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{
	[JsonObject]
	public class Group
	{
		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "name_searchable")]
		public string NameSearchable { get; set; }

		[JsonProperty(PropertyName = "all_songs_for_sid")]
		public List<Song> Songs { get; set; }
	}
}