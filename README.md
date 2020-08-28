# Azure App Configuration and Azure Key Vault Configuration Provider Test App

Output of this Azure Docs tutorial: [Tutorial: Use Key Vault references in an ASP.NET Core app](https://docs.microsoft.com/en-us/azure/azure-app-configuration/use-key-vault-references-dotnet-core?tabs=cmd%2Ccore2x).

## Setup and Config Notes

### 1. [Setup a Web App with Azure App Configuration](https://docs.microsoft.com/en-us/azure/azure-app-configuration/quickstart-aspnet-core-app?tabs=core3x).

- Under [Create an ASP.NET Core web app](https://docs.microsoft.com/en-us/azure/azure-app-configuration/quickstart-aspnet-core-app?tabs=core2x#create-an-aspnet-core-web-app) I ditched the `--no-https` flag when running `dotnet new mvc` because who wants no HTTPS? ¯\_(ツ)_/¯
- In local development, we can't use managed identity authentication, so we can't connect via Endpoint alone. This is why `settings[ConnectionStrings:AppConfig]` is used locally, rather than settings["AppConfig:Endpoint"] covered in part 3.
- Local secrets are set via  `dotnet user-secrets`.

### 2. [Use Key Vault references in an ASP.NET Core app](https://docs.microsoft.com/en-us/azure/azure-app-configuration/use-key-vault-references-dotnet-core?tabs=bash%2Ccore3x).

- This tutorial uses a service principal for Key Vault authentication. It provides the Azure CLI command for _creating_ a service principal in Azure. Where should the client ID, client secret and tenant ID be stored so others can run locally?

### 3. [Use managed identities to access App Configuration](https://docs.microsoft.com/en-us/azure/azure-app-configuration/howto-integrate-azure-managed-service-identity?tabs=core3x).