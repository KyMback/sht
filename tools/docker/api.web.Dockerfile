#############################################
######### BUILD SERVER

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-server

WORKDIR /usr/src/web-api

# Copy only packages metadata to use docker cache independent of other source

COPY /server/src/Api/SHT.Api.Web/SHT.Api.Web.csproj ./src/Api/SHT.Api.Web/

COPY /server/src/Application/SHT.Application/SHT.Application.csproj ./src/Application/SHT.Application/

COPY /server/src/Common/SHT.Common/SHT.Common.csproj ./src/Common/SHT.Common/
COPY /server/src/Common/SHT.Resources/SHT.Resources.csproj ./src/Common/SHT.Resources/

COPY /server/src/Domain/SHT.Domain.Common/SHT.Domain.Common.csproj ./src/Domain/SHT.Domain.Common/
COPY /server/src/Domain/SHT.Domain.Models/SHT.Domain.Models.csproj ./src/Domain/SHT.Domain.Models/
COPY /server/src/Domain/SHT.Domain.Questions/SHT.Domain.Questions.csproj ./src/Domain/SHT.Domain.Questions/
COPY /server/src/Domain/SHT.Domain.Tests/SHT.Domain.Tests.csproj ./src/Domain/SHT.Domain.Tests/
COPY /server/src/Domain/SHT.Domain.Users/SHT.Domain.Users.csproj ./src/Domain/SHT.Domain.Users/

COPY /server/src/Infrastructure/SHT.Infrastructure.Common/SHT.Infrastructure.Common.csproj ./src/Infrastructure/SHT.Infrastructure.Common/
COPY /server/src/Infrastructure/SHT.Infrastructure.BackgroundProcess/SHT.Infrastructure.BackgroundProcess.csproj ./src/Infrastructure/SHT.Infrastructure.BackgroundProcess/
COPY /server/src/Infrastructure/SHT.Infrastructure.Services/SHT.Infrastructure.Services.csproj ./src/Infrastructure/SHT.Infrastructure.Services/
COPY /server/src/Infrastructure/SHT.Infrastructure.Services.Abstractions/SHT.Infrastructure.Services.Abstractions.csproj ./src/Infrastructure/SHT.Infrastructure.Services.Abstractions/
COPY /server/src/Infrastructure/SHT.Infrastructure.DataAccess.Abstractions/SHT.Infrastructure.DataAccess.Abstractions.csproj ./src/Infrastructure/SHT.Infrastructure.DataAccess.Abstractions/
COPY /server/src/Infrastructure/SHT.Infrastructure.DataAccess.EF/SHT.Infrastructure.DataAccess.EF.csproj ./src/Infrastructure/SHT.Infrastructure.DataAccess.EF/
COPY /server/src/Infrastructure/SHT.Infrastructure.EF.Configs/SHT.Infrastructure.EF.Configs.csproj ./src/Infrastructure/SHT.Infrastructure.EF.Configs/

WORKDIR /usr/src/web-api/src/Api/SHT.Api.Web/
RUN dotnet restore "SHT.Api.Web.csproj"

COPY ./server /usr/src/web-api/
RUN dotnet publish -c Release -o out

# Build tools
WORKDIR /usr/src/web-api/tools/SHT.JsonSchemasGenerator
RUN dotnet build


#############################################
######### BUILD CLIENT

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-app

# install nodejs
RUN curl -sL https://deb.nodesource.com/setup_12.x | bash && \
    apt-get update \
    && apt-get install -y --allow-unauthenticated \
    nodejs

WORKDIR /usr/src/web-app

COPY /client/package.json ./client/package.json
COPY /client/package-lock.json ./client/package-lock.json

WORKDIR /usr/src/web-app/client
RUN npm install

COPY --from=build-server /usr/src/web-api/tools/SHT.JsonSchemasGenerator/bin/Debug/netcoreapp3.1 /usr/src/web-app/server/tools/SHT.JsonSchemasGenerator/bin/Debug/netcoreapp3.1
COPY /client .

RUN npm run build:prod


#################################################
############ RUNTIME
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 as final

WORKDIR /app

COPY --from=build-server /usr/src/web-api/src/Api/SHT.Api.Web/out ./
COPY --from=build-app /usr/src/web-app/client/build ./wwwroot

ENTRYPOINT ["dotnet", "SHT.Api.Web.dll"]