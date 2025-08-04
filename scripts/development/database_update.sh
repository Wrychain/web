#!/bin/bash

docker exec -t wrychain_aspnet_development bash -c "dotnet ef database update --project Wrychain.API"
