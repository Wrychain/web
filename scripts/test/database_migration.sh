#!/bin/bash

docker exec -t wrychain_aspnet_test bash -c "dotnet ef migrations add \"$@\" --project Wrychain.DAL"
