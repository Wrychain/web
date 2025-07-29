#!/bin/bash

# USER="{\"Username\": \"Test\"}"

# curl -k -X POST https://localhost/api/user \
#      -H "Content-Type: application/json" \
#      -d "$USER"

STATION="{\"Name\": \"Test\", \"CreatorId\": 1}"

# STATION="{\"Name\": \"Test\", \"CreatorId\": 1, \"Creator\": $USER, \"Members\": [$USER]}"

curl -k -X POST https://localhost/api/station \
     -H "Content-Type: application/json" \
     -d "$STATION"
