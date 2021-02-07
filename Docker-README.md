# Instructions for Docker

## Local Development

### Build

```powershell
docker build -t twitch-follows .
```

### Creating a Developer Certificate (PowerShell)

1. If you already have an exported .pfx, you can skip to step X.
2. Remove your existing developer certificate(s).

```powershell
dotnet dev-certs https --clean
```

3. Create, trust, and export your new developer certificate.

```powershell
dotnet dev-certs https --trust --export-path $env:USERPROFILE/.aspnet/https/aspnetapp.pfx -p <SECRETPASSWORD>
```

### Running

1. Setup your environment variables. Copy `.env-sample` to `.env` and edit the file to add your values.
2. Run the Docker container.

```powershell
docker run -it --rm -p 5000:80 -p 5001:443 `
--volume C:\Users\nullforce\.aspnet\https:/https/ `
--env-file .env `
--name twitch-follows `
twitch-follows
```
