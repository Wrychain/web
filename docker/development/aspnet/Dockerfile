FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /caspnetti

RUN apt update
RUN apt upgrade -y

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

ENTRYPOINT sleep infinity
