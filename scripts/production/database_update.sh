#!/bin/bash

docker exec -t wrychain_aspnet_production bash -c "dotnet ef database update --project Wrychain.API"
