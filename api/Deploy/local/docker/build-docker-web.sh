#!/usr/bin/env bash
#--------------------------------------------------------------------------------------
# Setup Environment Variables
#--------------------------------------------------------------------------------------
export AUTHOR=Martin Hunter
export CONTACT=martin@mytrucking.com
#--------------------------------------------------------------------------------------
export PRODUCT_DOMAIN=mytrucking
export PRODUCT_NAME=metric-api-web
export VERSION=1.0.3
export RELEASE=BETA.0.3
export SRC=./web
export DOCKER_PLATFORM=
#--------------------------------------------------------------------------------------
# Execute dotnet Commands
#--------------------------------------------------------------------------------------
./actions/docker-build.sh