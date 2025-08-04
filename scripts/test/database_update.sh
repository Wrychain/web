#!/bin/bash

docker exec -t wrychain_aspnet_test bash -c "dotnet ef database update --project Wrychain.API"
