FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "Acme.BookStore.sln" "Acme.BookStore.sln"

# Applications
COPY "apps/auth-server/src/Acme.BookStore.AuthServer/Acme.BookStore.AuthServer.csproj" "apps/auth-server/src/Acme.BookStore.AuthServer/Acme.BookStore.AuthServer.csproj"
COPY "apps/public-web/src/Acme.BookStore.PublicWeb/Acme.BookStore.PublicWeb.csproj" "apps/public-web/src/Acme.BookStore.PublicWeb/Acme.BookStore.PublicWeb.csproj"
COPY *"apps/blazor/src/Acme.BookStore.Blazor/Acme.BookStore.Blazor.csproj" "apps/blazor/src/Acme.BookStore.Blazor/Acme.BookStore.Blazor.csproj"
COPY *"apps/blazor/src/Acme.BookStore.Blazor.Server/Acme.BookStore.Blazor.Server.csproj" "apps/blazor/src/Acme.BookStore.Blazor.Server/Acme.BookStore.Blazor.Server.csproj"
COPY *"apps/web/src/Acme.BookStore.Web/Acme.BookStore.Web.csproj" "apps/web/src/Acme.BookStore.Web/Acme.BookStore.Web.csproj"

# Shared Projects
COPY "shared/Acme.BookStore.DbMigrator/Acme.BookStore.DbMigrator.csproj" "shared/Acme.BookStore.DbMigrator/Acme.BookStore.DbMigrator.csproj"
COPY "shared/Acme.BookStore.Shared.Hosting/Acme.BookStore.Shared.Hosting.csproj" "shared/Acme.BookStore.Shared.Hosting/Acme.BookStore.Shared.Hosting.csproj"
COPY "shared/Acme.BookStore.Shared.Hosting.Gateways/Acme.BookStore.Shared.Hosting.Gateways.csproj" "shared/Acme.BookStore.Shared.Hosting.Gateways/Acme.BookStore.Shared.Hosting.Gateways.csproj"
COPY "shared/Acme.BookStore.Shared.Hosting.Microservices/Acme.BookStore.Shared.Hosting.Microservices.csproj" "shared/Acme.BookStore.Shared.Hosting.Microservices/Acme.BookStore.Shared.Hosting.Microservices.csproj"
COPY "shared/Acme.BookStore.Shared.Hosting.AspNetCore/Acme.BookStore.Shared.Hosting.AspNetCore.csproj" "shared/Acme.BookStore.Shared.Hosting.AspNetCore/Acme.BookStore.Shared.Hosting.AspNetCore.csproj"
COPY "shared/Acme.BookStore.Shared.Hosting/Acme.BookStore.Shared.Hosting.csproj" "shared/Acme.BookStore.Shared.Hosting/Acme.BookStore.Shared.Hosting.csproj"
COPY "shared/Acme.BookStore.Shared.Localization/Acme.BookStore.Shared.Localization.csproj" "shared/Acme.BookStore.Shared.Localization/Acme.BookStore.Shared.Localization.csproj"

# Microservices
COPY "services/administration/src/Acme.BookStore.AdministrationService.HttpApi.Host/Acme.BookStore.AdministrationService.HttpApi.Host.csproj" "services/administration/src/Acme.BookStore.AdministrationService.HttpApi.Host/Acme.BookStore.AdministrationService.HttpApi.Host.csproj"
COPY "services/identity/src/Acme.BookStore.IdentityService.HttpApi.Host/Acme.BookStore.IdentityService.HttpApi.Host.csproj" "services/identity/src/Acme.BookStore.IdentityService.HttpApi.Host/Acme.BookStore.IdentityService.HttpApi.Host.csproj"
COPY "services/saas/src/Acme.BookStore.SaasService.HttpApi.Host/Acme.BookStore.SaasService.HttpApi.Host.csproj" "services/saas/src/Acme.BookStore.SaasService.HttpApi.Host/Acme.BookStore.SaasService.HttpApi.Host.csproj"
COPY "services/product/src/Acme.BookStore.ProductService.HttpApi.Host/Acme.BookStore.ProductService.HttpApi.Host.csproj" "services/product/src/Acme.BookStore.ProductService.HttpApi.Host/Acme.BookStore.ProductService.HttpApi.Host.csproj"
# Gateways
COPY "gateways/web/src/Acme.BookStore.WebGateway/Acme.BookStore.WebGateway.csproj" "gateways/web/src/Acme.BookStore.WebGateway/Acme.BookStore.WebGateway.csproj"
COPY "gateways/web-public/src/Acme.BookStore.PublicWebGateway/Acme.BookStore.PublicWebGateway.csproj" "gateways/web-public/src/Acme.BookStore.PublicWebGateway/Acme.BookStore.PublicWebGateway.csproj"

COPY "NuGet.Config" "NuGet.Config"

RUN dotnet restore "Acme.BookStore.sln"

COPY . .
WORKDIR "/src/services/saas/src/Acme.BookStore.SaasService.HttpApi.Host"
RUN dotnet publish -c Release -o /app
# Should be used after .net6 is out of preview for better performance
# RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Acme.BookStore.SaasService.HttpApi.Host.dll"]