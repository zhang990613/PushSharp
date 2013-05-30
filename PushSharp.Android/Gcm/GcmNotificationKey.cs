using System;
using PushSharp.Core;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace PushSharp.Android
{
	public static class GcmNotificationKey
	{
		const string GCM_NOTIFICATION_URL = "https://android.googleapis.com/gcm/notification";
		static HttpClient http = new HttpClient ();

		public static string CreateNotificationKey(this PushBroker broker, GcmPushChannelSettings settings, string keyName, params string[] registrationIds)
		{
			var json = new JObject ();
			json ["operation"] = "create";
			json ["notification_key_name"] = keyName;
			json ["registration_ids"] = new JArray (registrationIds);

			var sc = new StringContent (json.ToString ());
			sc.Headers.ContentType = new MediaTypeHeaderValue ("application/json");

			sc.Headers.TryAddWithoutValidation ("project_id", settings.SenderID);
			sc.Headers.TryAddWithoutValidation ("Authorization", "key=" + settings.SenderAuthToken);


			var response = http.PostAsync (GCM_NOTIFICATION_URL, sc).Result;

			var content = response.Content.ReadAsStringAsync ().Result;

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var j = JObject.Parse (content);
				return j ["notification_key"].ToString ();
			}

			throw new GcmNotificationKeyCreateException (content);
		}

		public static string AddRegistrationIds(this PushBroker broker, GcmPushChannelSettings settings, string keyName, string key, params string[] registrationIds)
		{
			var json = new JObject ();
			json ["operation"] = "add";
			json ["notification_key_name"] = keyName;
			json ["notification_key"] = key;
			json ["registration_ids"] = new JArray (registrationIds);

			var sc = new StringContent (json.ToString ());
			sc.Headers.ContentType = new MediaTypeHeaderValue ("application/json");

			sc.Headers.TryAddWithoutValidation ("project_id", settings.SenderID);
			sc.Headers.TryAddWithoutValidation ("Authorization", "key=" + settings.SenderAuthToken);


			var response = http.PostAsync (GCM_NOTIFICATION_URL, sc).Result;

			var content = response.Content.ReadAsStringAsync ().Result;

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var j = JObject.Parse (content);
				return j ["notification_key"].ToString ();
			}

			throw new GcmNotificationKeyAddRegistrationIdsException (content);
		}

		public static string RemoveRegistrationIds(this PushBroker broker, GcmPushChannelSettings settings, string keyName, string key, params string[] registrationIds)
		{
			var json = new JObject ();
			json ["operation"] = "remove";
			json ["notification_key_name"] = keyName;
			json ["notification_key"] = key;
			json ["registration_ids"] = new JArray (registrationIds);

			var sc = new StringContent (json.ToString ());
			sc.Headers.ContentType = new MediaTypeHeaderValue ("application/json");

			sc.Headers.TryAddWithoutValidation ("project_id", settings.SenderID);
			sc.Headers.TryAddWithoutValidation ("Authorization", "key=" + settings.SenderAuthToken);


			var response = http.PostAsync (GCM_NOTIFICATION_URL, sc).Result;

			var content = response.Content.ReadAsStringAsync ().Result;

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var j = JObject.Parse (content);
				return j ["notification_key"].ToString ();
			}

			throw new GcmNotificationKeyRemoveRegistrationIdsException (content);
		}
	}
}

