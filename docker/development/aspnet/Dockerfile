FROM mcr.microsoft.com/dotnet/sdk:10.0

WORKDIR /wrychain

RUN apt update
RUN apt upgrade -y

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet dev-certs https --trust

ENTRYPOINT sleep infinity
