using System.Collections.Generic;
using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{
	[JsonObject]
	public class Listeners
	{
		[JsonProperty(PropertyName = "guests")]
		public int Guests { get; set; }

		[JsonProperty(PropertyName = "users")]
		public List<User> Users { get; set; }
	}
}