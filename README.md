# .Net Core Fake Auth for Integration Tests
This is just an example on how to fake Authentication / Authorization via OpenID Connect for .NET Core (2.1 - 3.x) Web API Integration Tests using TestServer.

## Why this?
It's often the case that you have API controllers using the `[Authorize] ` attribute on class- or methodlevel, together with some OpenID Connect Server like Keycloak or IdentityServer.

In this case, Integration Testing won't work out of the Box, because you'll only get a `401 - Unauthorized` back when you try to reach these endpoints without a valid token. 

In the past, one often created some Test-Accounts in a dev/test environments' OIDC Server for that reason. Then inside the test one went to this OIDC Server to get the token directly via the `/token` endpoint in the past. 

This, however, has some serious drawbacks imho:
1) The need to have testaccounts, or more general an external dependence inside the project. With potential check-in of testaccount-credentials inside a repository.

2) At least for OIDC, it is not recommended to allow direct access to the /token endpoint for clients without further security measures like a shared secret / certificate - a.k.a. Bearer-Clients -  because there's a potential Attack Vector in terms of (D)DoS and more.
 
3) Apart from that, there may be some organizational overhead to create and manage these testaccounts

So, this library provides a way to simply Fake the Auth Middleware inside of .Net Core (from 2.0 upwards, at the state of writing it's 3.1). 

# Features
* Fake Auth for Integration Tests using TestServer (but should be agnostic to the mock-server you use)
* Possibility to set potentially needed Claims for methodcalls (TODO: Try to make it parametrizable on a per-test-base)
* (Nearly) no code change needed in the actual Project
* Library-agnostic (works using NUnit, XUnit, MSBuild, but should work with any other library)

#Status
Initial Commit, more to come 

#Licensing
Do what you want with it (MIT). When we meet, I drink beer and good whisky :beers: :grimacing:
