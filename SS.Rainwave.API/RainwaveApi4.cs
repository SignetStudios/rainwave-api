﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using log4net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SS.Rainwave.API.Objects;

namespace SS.Rainwave.API
{
	public class RainwaveApi4 : IRainwaveApi4
	{
		private readonly ILog _log;

		public RainwaveApi4(string apiEndpoint, string userId, string apiKey, ILog log = null)
		{
			if (string.IsNullOrWhiteSpace(apiEndpoint))
			{
				throw new ArgumentException("API Endpoint must be provided", nameof(apiEndpoint));
			}

			if (string.IsNullOrWhiteSpace(userId))
			{
				throw new ArgumentException("User ID must be provided", nameof(userId));
			}

			if (string.IsNullOrWhiteSpace(apiKey))
			{
				throw new ArgumentException("API Key must be provided", nameof(apiKey));
			}

			ApiEndpoint = apiEndpoint;
			UserId = userId;
			ApiKey = apiKey;

			_log = log ?? LogManager.GetLogger(typeof(RainwaveApi4));
		}


		public string ApiEndpoint { get; }

		public string UserId { get; }

		public string ApiKey { get; }

		public async Task<Album> Album(SiteId siteId, int albumId)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"id", albumId.ToString(CultureInfo.InvariantCulture)}
			};

			try
			{
				var result = await MakeRequest<Album>("album", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<Album>> AllAlbums(SiteId siteId, int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Album>>("all_albums", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<Artist>> AllArtists(SiteId siteId)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)}
			};

			try
			{
				var result = await MakeRequest<List<Artist>>("all_artists", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<Song>> AllFaves(int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"per_page", perPage.ToString(CultureInfo.InvariantCulture)},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Song>>("all_faves", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<Group>> AllGroups(SiteId siteId, int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Group>>("all_groups", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<Song>> AllSongs(SortOrder sortOrder, int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"order", ((int) sortOrder).ToString(CultureInfo.InvariantCulture)},
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Song>>("all_songs", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<Artist> Artist(SiteId siteId, int artistId)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"id", artistId.ToString(CultureInfo.InvariantCulture)}
			};

			try
			{
				var result = await MakeRequest<Artist>("artist", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<bool> ClearRating(SiteId siteId, int songId)
		{
			var parms = new Dictionary<string, string>
			{
				{"song_id", songId.ToString(CultureInfo.InvariantCulture)},
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)}
			};

			return await GetRequestSuccess("clear_rating", parms);
		}

		public async Task<bool> ClearRequests()
		{
			var result = await MakeRequest("clear_requests");

			try
			{
				var execTime = result["api_info"]["exectime"].Value<decimal>();

				return execTime > 0;
			}
			catch
			{
				return false;
			}
		}

		public async Task<List<User>> CurrentListeners(SiteId siteId, int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<User>>("current_listeners", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<bool> DeleteRequest(int songId, SiteId siteId)
		{
			var parms = new Dictionary<string, string>
			{
				{"song_id", songId.ToString(CultureInfo.InvariantCulture)},
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)}
			};

			return await GetRequestSuccess("delete_request", parms);
		}

		public async Task<bool> FaveAlbum(SiteId siteId, int albumId, bool fave)
		{
			var parms = new Dictionary<string, string>
			{
				{"album_id", albumId.ToString(CultureInfo.InvariantCulture)},
				{"fave", fave.ToString()},
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)}
			};

			return await GetRequestSuccess("fave_album", parms);
		}

		public async Task<bool> FaveSong(SiteId siteId, int songId, bool fave)
		{
			var parms = new Dictionary<string, string>
			{
				{"song_id", songId.ToString(CultureInfo.InvariantCulture)},
				{"fave", fave.ToString().ToLower()},
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)}
			};

			return await GetRequestSuccess("fave_song", parms);
		}

		public async Task<Group> Group(SiteId siteId, int groupId)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"id", groupId.ToString(CultureInfo.InvariantCulture)}
			};

			try
			{
				var result = await MakeRequest<Group>("group", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<Info> Info(SiteId siteId, bool currentListeners = false, bool allAlbums = false)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"current_listeners", currentListeners.ToString().ToLower()},
				{"all_albums", allAlbums.ToString().ToLower()}
			};

			try
			{
				var result = await MakeRequest<Info>("info", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<Info>> InfoAll(SiteId siteId, int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Info>>("info_all", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<User> Listener(int id)
		{
			var parms = new Dictionary<string, string>
			{
				{"id", id.ToString()}
			};

			try
			{
				var result = await MakeRequest<User>("listener", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<bool> OrderRequests(string songIdList, SiteId siteId)
		{
			var parms = new Dictionary<string, string>
			{
				{"order", songIdList},
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)}
			};

			return await GetRequestSuccess("order_requests", parms);
		}

		public async Task<bool> PauseRequestQueue(SiteId siteId)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)}
			};

			return await GetRequestSuccess("pause_request_queue", parms);
		}

		public async Task<List<Song>> PlaybackHistory(SiteId siteId, int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Song>>("playback_history", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<bool> Rate(SiteId siteId, int songId, decimal rating)
		{
			var parms = new Dictionary<string, string>
			{
				{"song_id", songId.ToString(CultureInfo.InvariantCulture)},
				{"rating", rating.ToString(CultureInfo.InvariantCulture)},
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)}
			};

			return await GetRequestSuccess("rate", parms);
		}

		public async Task<bool> Request(SiteId siteId, int songId)
		{
			var parms = new Dictionary<string, string>
			{
				{"song_id", songId.ToString(CultureInfo.InvariantCulture)},
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)}
			};

			return await GetRequestSuccess("request", parms);
		}

		public async Task<bool> RequestFavoritedSongs(SiteId siteId, int limit = int.MaxValue)
		{
			var parms = new Dictionary<string, string>
			{
				{"limit", limit.ToString(CultureInfo.InvariantCulture)},
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)}
			};

			return await GetRequestSuccess("request_favorited_songs", parms);
		}

		public async Task<List<Request>> RequestLine(SiteId siteId, int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Request>>("request_line", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<bool> RequestUnratedSongs(SiteId siteId, int limit = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)}
			};

			if (limit > 0) parms.Add("limit", limit.ToString(CultureInfo.InvariantCulture));

			return await GetRequestSuccess("request_unrated_songs", parms);
		}

		public async Task<Search> Search(SiteId siteId, string searchString)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"search", searchString}
			};

			try
			{
				var result = await MakeRequest<Search>("artist", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<Song> Song(SiteId siteId, int songId)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"id", songId.ToString(CultureInfo.InvariantCulture)}
			};

			try
			{
				var result = await MakeRequest<Song>("song", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<Dictionary<SiteId, int>> StationSongCount()
		{
			try
			{
				var rets = await MakeRequest<List<dynamic>>("station_song_count");

				return rets.ToDictionary<dynamic, SiteId, int>(ret => ret.sid, ret => ret.song_count);
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<Station>> Stations(int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Station>>("stations", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<Info> Sync(SiteId siteId, bool offlineAck = false, bool resync = false, int knownEventId = -1)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"offline_ack", offlineAck.ToString()},
				{"resync", resync.ToString()}
			};

			if (knownEventId > 0)
			{
				parms.Add("known_event_id", knownEventId.ToString(CultureInfo.InvariantCulture));
			}

			try
			{
				var result = await MakeRequest<Info>("sync", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<Donation>> TipJar(int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Donation>>("tip_jar", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<Song>> Top100(int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Song>>("top_100", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<Song>> UnratedSongs(SiteId siteId, int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Song>>("unrated_songs", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<bool> UnpauseRequestQueue(SiteId siteId)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)}
			};
			return await GetRequestSuccess("unpause_request_queue", parms);
		}

		public async Task<User> UserInfo(int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<User>("user_info", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<Song>> UserRecentVotes(SiteId siteId, int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Song>>("user_recent_votes", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<Song>> UserRequestedHistory(SiteId siteId, int perPage = 0, int pageStart = 0)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"per_page", perPage.ToString()},
				{"page_start", pageStart.ToString()}
			};

			try
			{
				var result = await MakeRequest<List<Song>>("user_requested_history", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<List<User>> UserSearch(string userName)
		{
			var parms = new Dictionary<string, string>
			{
				{"username", userName}
			};

			try
			{
				var result = await MakeRequest<List<User>>("user_search", parms);

				return result;
			}
			catch
			{
				return null;
			}
		}

		public async Task<bool> Vote(SiteId siteId, int entryId)
		{
			var parms = new Dictionary<string, string>
			{
				{"sid", ((int) siteId).ToString(CultureInfo.InvariantCulture)},
				{"entry_id", entryId.ToString(CultureInfo.InvariantCulture)}
			};

			return await GetRequestSuccess("vote", parms);
		}

		private async Task<bool> GetRequestSuccess(string url, Dictionary<string, string> additionalValues = null)
		{
			var result = await MakeRequest(url, additionalValues);

			try
			{
				var success = result[url + "_result"]["success"].Value<bool>();

				return success;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		///     Makes a request to the API endpoint and returns the response
		/// </summary>
		/// <typeparam name="T">The type of object the request should be deserialized to</typeparam>
		/// <param name="url">The specific URL endpoint to send the response to</param>
		/// <param name="additionalValues">Any additional parameters that should be passed with the request</param>
		/// <returns>An object of type T containing the response</returns>
		private async Task<T> MakeRequest<T>(string url, Dictionary<string, string> additionalValues = null)
			where T : class
		{
			var attempt = 1;

			_log.Debug($"Begin request: \"{url}\"");
			
			var parms = new Dictionary<string, string>
			{
				{"user_id", UserId},
				{"key", ApiKey}
			};

			if (additionalValues != null)
			{
				foreach (var value in additionalValues)
				{
					_log.Debug($"{value.Key}: {value.Value}");
					parms.Add(value.Key, value.Value);
				}
			}

			while (attempt <= 3)
			{
				using (var client = new HttpClient())
				{
					var content = new FormUrlEncodedContent(parms);

					var result = await client.PostAsync($"{ApiEndpoint}/{url}", content);

					if (!result.IsSuccessStatusCode)
					{
						switch (result.StatusCode)
						{
							case HttpStatusCode.BadGateway:
								_log.Debug("Suppressing 502 BadGateway error.");
								//suppress BadGateway
								break;
							default:
								_log.Error($"Error with {url} ({result.StatusCode}: {result.ReasonPhrase})");
								break;
						}

						attempt++;
						continue;
					}

					var responseString = await result.Content.ReadAsStringAsync();
					var returnVal = JsonConvert.DeserializeObject<T>(responseString, new JsonSerializerSettings
					{
						NullValueHandling = NullValueHandling.Ignore
					});

					_log.Debug($"Request to \"{url}\" successful.");

					return returnVal;
				}
			}

			return null;
		}

		/// <summary>
		///     Makes a request to the API endpoint and returns the response
		/// </summary>
		/// <param name="url">The specific URL endpoint to send the response to</param>
		/// <param name="additionalValues">Any additional parameters that should be passed with the request</param>
		/// <returns>A dynamic object representing the JSON result</returns>
		private async Task<JObject> MakeRequest(string url, Dictionary<string, string> additionalValues = null)
		{
			return await MakeRequest<JObject>(url, additionalValues);
		}
	}
}