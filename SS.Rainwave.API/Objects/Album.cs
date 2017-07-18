using System.Collections.Generic;
using Newtonsoft.Json;

namespace SS.Rainwave.API.Objects
{
	[JsonObject]
	public class Album
	{

		[JsonProperty(PropertyName = "added_on")]
		public int AddedOn { get; set; }

		[JsonProperty(PropertyName = "art")]
		public string Art { get; set; }

		[JsonProperty(PropertyName = "cool")]
		public bool Cool { get; set; }

		[JsonProperty(PropertyName = "cool_lowest")]
		public int CoolLowest { get; set; }

		[JsonProperty(PropertyName = "cool_multiply")]
		public int CoolMultiply { get; set; }

		[JsonProperty(PropertyName = "cool_override")]
		public bool CoolOverride { get; set; }

		[JsonProperty(PropertyName = "fave")]
		public bool Fave { get; set; }

		[JsonProperty(PropertyName = "fave_count")]
		public int FaveCount { get; set; }

		[JsonProperty(PropertyName = "genres")]
		public List<Genre> Genres { get; set; }

		[JsonProperty(PropertyName = "id")]
		public int Id { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "name_searchable")]
		public string NameSearchable { get; set; }

		[JsonProperty(PropertyName = "played_last")]
		public int PlayedLast { get; set; }

		[JsonProperty(PropertyName = "rating")]
		public decimal Rating { get; set; }

		[JsonProperty(PropertyName = "rating_complete")]
		public bool RatingComplete { get; set; }

		//Not quite sure how to do this one...
		//[JsonProperty(PropertyName = "rating_histogram")]
		//public RatingHistogram RatingHistogram { get; set; }

		[JsonProperty(PropertyName = "rating_rank")]
		public int RatingRank { get; set; }

		[JsonProperty(PropertyName = "rating_rank_percentile")]
		public int RatingRankPercentile { get; set; }

		[JsonProperty(PropertyName = "rating_user")]
		public decimal RatingUser { get; set; }

		[JsonProperty(PropertyName = "request_count")]
		public int RequestCount { get; set; }

		[JsonProperty(PropertyName = "request_rank")]
		public int RequestRank { get; set; }

		[JsonProperty(PropertyName = "request_rank_percentile")]
		public int RequestRankPercentile { get; set; }

		[JsonProperty(PropertyName = "song_count")]
		public int SongCount { get; set; }

		[JsonProperty(PropertyName = "songs")]
		public List<Song> Songs { get; set; }

		[JsonProperty(PropertyName = "title")]
		public string Title { get; set; }

		[JsonProperty(PropertyName = "vote_count")]
		public int VoteCount { get; set; }

		[JsonProperty(PropertyName = "year")]
		public int? Year { get; set; }
	}

	//public class RatingHistogram
	//{
	//}
}
