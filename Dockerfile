FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

RUN apt-get update
RUN apt-get install nuget -y


WORKDIR /app
COPY ./examples/EiffelClient.SubscriberOne/*.csproj         ./examples/EiffelClient.SubscriberOne/
COPY ./examples/EiffelClient.SubscriberTwo/*.csproj         ./examples/EiffelClient.SubscriberTwo/


RUN dotnet restore "examples/EiffelClient.SubscriberOne/EiffelClient.SubscriberOne.csproj"
RUN dotnet restore "examples/EiffelClient.SubscriberTwo/EiffelClient.SubscriberTwo.csproj"
# Copy everything
COPY . ./


# Build
RUN dotnet publish -c Release -o out "./examples/EiffelClient.SubscriberOne/EiffelClient.SubscriberOne.csproj"
RUN dotnet publish -c Release -o out "./examples/EiffelClient.SubscriberTwo/EiffelClient.SubscriberTwo.csproj"

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime:6.0

WORKDIR /app
COPY --from=build-env /app/out .

#ENTRYPOINT ["dotnet", "EiffelClient.SubscriberOne.dll"]
