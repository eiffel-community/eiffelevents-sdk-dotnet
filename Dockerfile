FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

RUN apt-get update
RUN apt-get install nuget -y


WORKDIR /app
COPY ./clients/EiffelClient.SubscriberOne/*.csproj         ./clients/EiffelClient.SubscriberOne/
COPY ./clients/EiffelClient.SubscriberTwo/*.csproj         ./clients/EiffelClient.SubscriberTwo/


RUN dotnet restore "clients/EiffelClient.SubscriberOne/EiffelClient.SubscriberOne.csproj"
RUN dotnet restore "clients/EiffelClient.SubscriberTwo/EiffelClient.SubscriberTwo.csproj"
# Copy everything
COPY . ./


# Build
RUN dotnet publish -c Release -o out "./clients/EiffelClient.SubscriberOne/EiffelClient.SubscriberOne.csproj"
RUN dotnet publish -c Release -o out "./clients/EiffelClient.SubscriberTwo/EiffelClient.SubscriberTwo.csproj"

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:6.0

WORKDIR /app
COPY --from=build-env /app/out .

#ENTRYPOINT ["dotnet", "EiffelClient.SubscriberOne.dll"]
