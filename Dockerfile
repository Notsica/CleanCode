# First stage - build and test
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o /app/build
COPY run_tests.sh .
RUN chmod +x run_tests.sh
RUN ./run_tests.sh

# Second stage - run
FROM mcr.microsoft.com/dotnet/runtime:8.0
WORKDIR /app
COPY --from=build /app/build .
ENTRYPOINT ["dotnet", "CleanCode.dll"]
