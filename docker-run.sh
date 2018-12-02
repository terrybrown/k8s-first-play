#!/bin/bash

# Kill the container in case it's already running
docker rm k8s-simple-api >/dev/null 2>/dev/null

# This relies on our docker image having been built with a name of 'statuscoder'.
# --name is the name you want to give the container you're starting. It can be anything you want.
# --publish defines on which local port (of the host machine) our application be bound.
docker run --name k8s-simple-api --publish 5001:5001 k8s-simple-api
