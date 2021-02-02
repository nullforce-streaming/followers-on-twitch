# Followers on Twitch

A simple Blazor Web App that authenticates with Twitch and displays followers for the logged in user.

## Requirements

### Configuration

You must provide a Twitch App Client ID and Secret by using either:

- Environment Variables
  - TWITCH__CLIENTID
  - TWITCH__CLIENTSECRET
- appsettings.json
  - "Twitch:ClientId"
  - "Twitch:ClientSecret"


### Runtime

- .NET 5

## References

- [AspNet.Security.OAuth.Twitch](https://github.com/aspnet-contrib/AspNet.Security.OAuth.Providers)
