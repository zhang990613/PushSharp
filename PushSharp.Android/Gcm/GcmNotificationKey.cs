using System;
using PushSharp.Core;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace PushSharp.Android
{
	public static class GcmNotificationKey
	{
		const string GCM_NOTIFICATION_URL = "https://android.googleapis.com/gcm/notification";

		public static void CreateNotificationKey(this PushBroker broker, GcmPushChannelSettings settings, string keyName, params string[] registrationIds)
		{
			var http = new HttpClient ();
			http.DefaultRequestHeaders.Add ("content-type", "application/json");
			http.DefaultRequestHeaders.Add ("project_id", settings.SenderID);
			http.DefaultRequestHeaders.Add ("Authorization", "key=" + settings.SenderAuthToken);

			var json = new JObject ();
			json ["operation"] = "create";
			json ["notification_key_name"] = keyName;
			json ["registration_ids"] = new JArray (registrationIds);

			http.PostAsync (GCM_NOTIFICATION_URL, new StringContent (json.ToString())).ContinueWith (t => {
				//{ "notification_key": "aUniqueKey" }

				var res = t.Result;


			});
		}
	}
}

