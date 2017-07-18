using System.Collections.Generic;
using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{
	[JsonObject]
	public class Listener
	{
		public string Rank { get; set; }
		public int WinningVotes { get; set; }
		public int TotalVotes { get; set; }
		public int TotalRatings { get; set; }
		public int UserId { get; set; }
		public List<RequestCount> RequestsBySourceStation { get; set; }
		public List<RatingCount> RatingSpread { get; set; }
		public int LosingRequests { get; set; }
		public string Avatar { get; set; }
		public int MindChanges { get; set; }
		public int WinningRequests { get; set; }
		public List<StationRating> RatingsByStation { get; set; }
		public int LosingVotes { get; set; }
		public string Name { get; set; }
		public List<RequestCount> RequestsByStation { get; set; }
		public List<StationVotes> VotesByStation { get; set; }
		public string Colour { get; set; }
		public int RegDate { get; set; }
		public List<Album> TopAlbums { get; set; }
		public RatingCompletion RatingCompletion { get; set; }
		public List<Album> TopRequestAlbums { get; set; }
		public int TotalRequests { get; set; }
	}
}