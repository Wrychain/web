#!/bin/bash

SCRIPT_DIR="$(dirname "$0")"

"$SCRIPT_DIR/database_drop.sh"
"$SCRIPT_DIR/database_update.sh"
