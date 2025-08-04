#!/bin/bash

docker exec -t wrychain_aspnet_production bash -c "dotnet ef migrations add \"$@\" --project Wrychain.DAL"
