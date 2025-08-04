#!/bin/bash

docker exec -it wrychain_aspnet_production bash -c "dotnet ef database drop --project Wrychain.API"
