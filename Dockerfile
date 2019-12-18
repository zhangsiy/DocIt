# Build stage

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /build

COPY src/ src/
COPY *.sln ./
RUN dotnet restore *.sln

COPY . .

# See that it builds
RUN dotnet build *.sln -c Release

# Package it up for deployment
RUN dotnet publish -c Release -o /app src/DocIt/*.csproj


# Run stage

FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app
EXPOSE 80

COPY --from=0 /app .

ENTRYPOINT ["dotnet", "DocIt.dll"]
