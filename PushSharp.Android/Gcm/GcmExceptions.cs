using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PushSharp.Android
{
	public class GcmNotificationKeyCreateException : Exception
	{
		public GcmNotificationKeyCreateException(string msg)
			: base(msg)
		{
		}
	}

	public class GcmNotificationKeyAddRegistrationIdsException : Exception
	{
		public GcmNotificationKeyAddRegistrationIdsException(string msg)
			: base(msg)
		{
		}
	}

	public class GcmNotificationKeyRemoveRegistrationIdsException : Exception
	{
		public GcmNotificationKeyRemoveRegistrationIdsException(string msg)
			: base(msg)
		{
		}
	}

	public class GcmMessageTransportException : Exception
	{
		public GcmMessageTransportException(string message, GcmMessageTransportResponse response)
			: base(message)
		{
			this.Response = response;
		}

		public GcmMessageTransportResponse Response
		{
			get;
			private set;
		}
	}

	public class GcmBadRequestTransportException : GcmMessageTransportException
	{
		public GcmBadRequestTransportException(GcmMessageTransportResponse response)
			: base("Bad Request or Malformed JSON", response)
		{
		}
	}

	public class GcmAuthenticationErrorTransportException : GcmMessageTransportException
	{
		public GcmAuthenticationErrorTransportException(GcmMessageTransportResponse response)
			: base("Authentication Failed", response)
		{
		}
	}

	public class GcmServiceUnavailableTransportException : GcmMessageTransportException
	{
		public GcmServiceUnavailableTransportException(TimeSpan retryAfter, GcmMessageTransportResponse response)
			: base("Service Temporarily Unavailable.  Please wait the retryAfter amount and implement an Exponential Backoff", response)
		{
			this.RetryAfter = retryAfter;
		}

		public TimeSpan RetryAfter
		{
			get;
			private set;
		}
	}
}
