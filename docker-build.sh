#!/bin/bash

# --tag define the name of the Docker image we're building. This is how we'll be able to reference this image
# later on from, e.g., 'docker run'. You can add an optional tag after this name following the format: <name>:<tag>.
# It's useful to create versioned images. E.g. --tag statuscoder:v1
docker build ./src/simple-api/ --tag k8s-simple-api
