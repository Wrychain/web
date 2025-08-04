#!/bin/bash

docker exec -it wrychain_aspnet_test bash -c "dotnet ef database drop --project Wrychain.API"
