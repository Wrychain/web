#!/bin/bash

# Check if the URL argument is provided
if [ -z "$1" ]; then
    echo "Usage: $0 user@host"
    exit 1
fi

REMOTE="$1"
REMOTE_COMMANDS=$(cat <<'ENDSSH'
echo "Pulling lastest refs from remote"
cd ~/projects/wryco/wryco-web
git pull origin master
echo "Rebuilding docker images"
./scripts/production/docker_build.sh
echo "Recreating docker containers"
./scripts/production/docker_up.sh
echo "Exiting session"
exit
ENDSSH
)

ssh "$REMOTE" "$REMOTE_COMMANDS"
