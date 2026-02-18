#!/bin/bash

# Define parameters
USERNAME='maalik'
DISPLAY_NAME='maalik'
PASSWORD=']@gA=%zLItK39XRg8YEJzbh4W:Vg1I2Y:./I-y~uZ:x$eY5CmSW$!KdGK)7pDn-'
PASSWORD_HASH='4kwBmNh9MKowu8lSw4m9XwcSbrcaZX8lhrQS4hj0SFCZ571ZH9DntTg1WMxSu/xz0wiO5kIjiBMue8F82HiJhg=='
URL="https://localhost/api/auth/login"
COOKIE_FILE="./cookies.txt"

# Assemble payload
DATA="{\"username\":\"${USERNAME}\",\"password\":\"${PASSWORD}\"}"

# Login
RESPONSE=$(curl -k -X POST -H "Content-Type: application/json" -d "$DATA" "$URL" -c "$COOKIE_FILE")
echo $RESPONSE

# Evaluate result
valid=$(echo "$RESPONSE" | grep -o '"valid":[[:space:]]*[^,}]*' | sed 's/"valid":[[:space:]]*//')
if [ "$valid" = "true" ]; then
    echo "The key 'valid' is true."
    exit 0
else
    echo "The key 'valid' is not true."
    exit 1
fi
