﻿//-----------------------------------------------------------------------
// <copyright file="MockRealm.cs" company="Outercurve Foundation">
//     Copyright (c) Outercurve Foundation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOpenAuth.Test.Mocks {
	using System;
	using System.Collections.Generic;
	using System.Diagnostics.Contracts;
	using DotNetOpenAuth.Messaging;
	using DotNetOpenAuth.OpenId;

	internal class MockRealm : Realm {
		private RelyingPartyEndpointDescription[] relyingPartyDescriptions;

		/// <summary>
		/// Initializes a new instance of the <see cref="MockRealm"/> class.
		/// </summary>
		/// <param name="wrappedRealm">The wrapped realm.</param>
		/// <param name="relyingPartyDescriptions">The relying party descriptions.</param>
		internal MockRealm(Realm wrappedRealm, params RelyingPartyEndpointDescription[] relyingPartyDescriptions)
			: base(wrappedRealm) {
			Requires.NotNull(relyingPartyDescriptions, "relyingPartyDescriptions");

			this.relyingPartyDescriptions = relyingPartyDescriptions;
		}

		/// <summary>
		/// Searches for an XRDS document at the realm URL, and if found, searches
		/// for a description of a relying party endpoints (OpenId login pages).
		/// </summary>
		/// <param name="requestHandler">The mechanism to use for sending HTTP requests.</param>
		/// <param name="allowRedirects">Whether redirects may be followed when discovering the Realm.
		/// This may be true when creating an unsolicited assertion, but must be
		/// false when performing return URL verification per 2.0 spec section 9.2.1.</param>
		/// <returns>
		/// The details of the endpoints if found, otherwise null.
		/// </returns>
		internal override IEnumerable<RelyingPartyEndpointDescription> DiscoverReturnToEndpoints(IDirectWebRequestHandler requestHandler, bool allowRedirects) {
			return this.relyingPartyDescriptions;
		}
	}
}
