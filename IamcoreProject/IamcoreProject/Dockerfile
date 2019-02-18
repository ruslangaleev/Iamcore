FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["IamcoreProject/IamcoreProject.csproj", "IamcoreProject/"]
RUN dotnet restore "IamcoreProject/IamcoreProject.csproj"
COPY . .
WORKDIR "/src/IamcoreProject"
RUN dotnet build "IamcoreProject.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "IamcoreProject.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "IamcoreProject.dll"]