#!/bin/bash

# Create user

USERNAME='maalik'
PASSWORD=']@gA=%zLItK39XRg8YEJzbh4W:Vg1I2Y:./I-y~uZ:x$eY5CmSW$!KdGK)7pDn-'
PASSWORD_HASH='4kwBmNh9MKowu8lSw4m9XwcSbrcaZX8lhrQS4hj0SFCZ571ZH9DntTg1WMxSu/xz0wiO5kIjiBMue8F82HiJhg=='

# COOKIE_FILE="./cookies.txt"
# URL="https://localhost/api/user"
# DATA='{"username": "maalik", "passwordHash": "4kwBmNh9MKowu8lSw4m9XwcSbrcaZX8lhrQS4hj0SFCZ571ZH9DntTg1WMxSu/xz0wiO5kIjiBMue8F82HiJhg==", "displayName": "maalik"}'
# RESPONSE=$(curl -k -X POST -H "Content-Type: application/json" -d "$DATA" "$URL" -b "$COOKIE_FILE" -c "$COOKIE_FILE")
# echo $RESPONSE
# exit 1

# Login

COOKIE_FILE="./cookies.txt"
URL="https://localhost/api/login"
DATA='{"username": "maalik", "password": "]@gA=%zLItK39XRg8YEJzbh4W:Vg1I2Y:./I-y~uZ:x$eY5CmSW$!KdGK)7pDn-"}'
RESPONSE=$(curl -k -X POST -H "Content-Type: application/json" -d "$DATA" "$URL" -b "$COOKIE_FILE" -c "$COOKIE_FILE")
echo $RESPONSE
exit 1

# Evaluate result

valid=$(echo "$response" | grep -o '"valid":[[:space:]]*[^,}]*' | sed 's/"valid":[[:space:]]*//')
if [ "$valid" = "true" ]; then
    echo "The key 'valid' is true."
else
    echo "The key 'valid' is not true."
fi
