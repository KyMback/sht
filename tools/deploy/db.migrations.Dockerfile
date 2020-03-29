FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-server

WORKDIR /usr/src/db-migration

# Copy only packages metadata to use docker cache independent of other source

COPY /server/src/Database/SHT.Database.EF.Migrations/SHT.Database.EF.Migrations.csproj ./src/Database/SHT.Database.EF.Migrations/
COPY /server/src/Database/SHT.Database.Defaults/SHT.Database.Defaults.csproj ./src/Database/SHT.Database.Defaults/

COPY /server/src/Domain/SHT.Domain.Services/SHT.Domain.Services.csproj ./src/Domain/SHT.Domain.Services/
COPY /server/src/Domain/SHT.Domain.Models/SHT.Domain.Models.csproj ./src/Domain/SHT.Domain.Models/

COPY /server/src/Infrastructure/SHT.Infrastructure.Common/SHT.Infrastructure.Common.csproj ./src/Infrastructure/SHT.Infrastructure.Common/
COPY /server/src/Infrastructure/SHT.Infrastructure.Services/SHT.Infrastructure.Services.csproj ./src/Infrastructure/SHT.Infrastructure.Services/
COPY /server/src/Infrastructure/SHT.Infrastructure.DataAccess.Abstractions/SHT.Infrastructure.DataAccess.Abstractions.csproj ./src/Infrastructure/SHT.Infrastructure.DataAccess.Abstractions/
COPY /server/src/Infrastructure/SHT.Infrastructure.DataAccess.EF/SHT.Infrastructure.DataAccess.EF.csproj ./src/Infrastructure/SHT.Infrastructure.DataAccess.EF/
COPY /server/src/Infrastructure/SHT.Infrastructure.EF.Configs/SHT.Infrastructure.EF.Configs.csproj ./src/Infrastructure/SHT.Infrastructure.EF.Configs/

WORKDIR /usr/src/db-migration/src/Database/SHT.Database.EF.Migrations/
RUN dotnet restore "SHT.Database.EF.Migrations.csproj"

COPY ./server /usr/src/db-migration/

ENTRYPOINT [ "dotnet", "run" ]