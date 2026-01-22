#!/bin/bash

# Define parameters
USERNAME='maalik'
DISPLAY_NAME='maalik'
PASSWORD=']@gA=%zLItK39XRg8YEJzbh4W:Vg1I2Y:./I-y~uZ:x$eY5CmSW$!KdGK)7pDn-'
PASSWORD_HASH='4kwBmNh9MKowu8lSw4m9XwcSbrcaZX8lhrQS4hj0SFCZ571ZH9DntTg1WMxSu/xz0wiO5kIjiBMue8F82HiJhg=='
URL="https://localhost/api/user"

# Assemble payload
DATA="{\"username\":\"${USERNAME}\",\"passwordHash\":\"${PASSWORD_HASH}\",\"displayName\":\"${DISPLAY_NAME}\"}"

# Fire response
RESPONSE=$(curl -k -X POST -H "Content-Type: application/json" -d "$DATA" "$URL")

# Print response
echo $RESPONSE
exit 1
