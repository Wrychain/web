#!/bin/bash

docker exec -it wrychain_aspnet_development bash -c "dotnet ef database drop --project Wrychain.API"
