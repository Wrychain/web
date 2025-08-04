#!/bin/bash

docker exec -t wrychain_aspnet_development bash -c "dotnet ef migrations add \"$@\" --project Wrychain.DAL"
