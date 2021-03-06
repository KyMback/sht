#############################################
######### BUILD SERVER

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-server

WORKDIR /usr/src/bg-host

# Copy only packages metadata to use docker cache independent of other source

COPY /server/src/BackgroundProcess/SHT.BackgroundProcess.Host/SHT.BackgroundProcess.Host.csproj ./src/BackgroundProcess/SHT.BackgroundProcess.Host/
COPY /server/src/BackgroundProcess/SHT.BackgroundProcess.Jobs/SHT.BackgroundProcess.Jobs.csproj ./src/BackgroundProcess/SHT.BackgroundProcess.Jobs/

COPY /server/src/Application/SHT.Application/SHT.Application.csproj ./src/Application/SHT.Application/

COPY /server/src/Common/SHT.Common/SHT.Common.csproj ./src/Common/SHT.Common/
COPY /server/src/Common/SHT.Resources/SHT.Resources.csproj ./src/Common/SHT.Resources/

COPY /server/src/Domain/SHT.Domain.Common/SHT.Domain.Common.csproj ./src/Domain/SHT.Domain.Common/
COPY /server/src/Domain/SHT.Domain.Models/SHT.Domain.Models.csproj ./src/Domain/SHT.Domain.Models/
COPY /server/src/Domain/SHT.Domain.Questions/SHT.Domain.Questions.csproj ./src/Domain/SHT.Domain.Questions/
COPY /server/src/Domain/SHT.Domain.Tests/SHT.Domain.Tests.csproj ./src/Domain/SHT.Domain.Tests/
COPY /server/src/Domain/SHT.Domain.Users/SHT.Domain.Users.csproj ./src/Domain/SHT.Domain.Users/

COPY /server/src/Infrastructure/SHT.Infrastructure.Common/SHT.Infrastructure.Common.csproj ./src/Infrastructure/SHT.Infrastructure.Common/
COPY /server/src/Infrastructure/SHT.Infrastructure.FileStorage/SHT.Infrastructure.FileStorage.csproj ./src/Infrastructure/SHT.Infrastructure.FileStorage/
COPY /server/src/Infrastructure/SHT.Infrastructure.BackgroundProcess/SHT.Infrastructure.BackgroundProcess.csproj ./src/Infrastructure/SHT.Infrastructure.BackgroundProcess/
COPY /server/src/Infrastructure/SHT.Infrastructure.Services/SHT.Infrastructure.Services.csproj ./src/Infrastructure/SHT.Infrastructure.Services/
COPY /server/src/Infrastructure/SHT.Infrastructure.DataAccess.Abstractions/SHT.Infrastructure.DataAccess.Abstractions.csproj ./src/Infrastructure/SHT.Infrastructure.DataAccess.Abstractions/
COPY /server/src/Infrastructure/SHT.Infrastructure.DataAccess.EF/SHT.Infrastructure.DataAccess.EF.csproj ./src/Infrastructure/SHT.Infrastructure.DataAccess.EF/
COPY /server/src/Infrastructure/SHT.Infrastructure.EF.Configs/SHT.Infrastructure.EF.Configs.csproj ./src/Infrastructure/SHT.Infrastructure.EF.Configs/

WORKDIR /usr/src/bg-host/src/BackgroundProcess/SHT.BackgroundProcess.Host/
RUN dotnet restore "SHT.BackgroundProcess.Host.csproj"

COPY ./server /usr/src/bg-host/
RUN dotnet publish -c Release -o out


#################################################
############ RUNTIME
FROM mcr.microsoft.com/dotnet/core/runtime:3.1 as final

WORKDIR /app

COPY --from=build-server /usr/src/bg-host/src/BackgroundProcess/SHT.BackgroundProcess.Host/out ./

ENTRYPOINT ["dotnet", "SHT.BackgroundProcess.Host.dll"]