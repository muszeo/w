#!/usr/bin/env bash
#--------------------------------------------------------------------------------------
# Setup Environment Variables
#--------------------------------------------------------------------------------------
export AUTHOR=Martin Hunter
export CONTACT=martin@mytrucking.com
export PRODUCT_DOMAIN=mytrucking
export PRODUCT_NAME=metric-api-web
export VERSION=1.0.3
export RELEASE=BETA.0.3
export SRC=./web
export HOST_PORT=39813
export GUEST_PORT=80
export APP_ENVIRONMENT=Docker
#export APP_ENVIRONMENT=Sit
#export APP_ENVIRONMENT=Preprod
#export APP_ENVIRONMENT=Prod
#--------------------------------------------------------------------------------------
# Execute dotnet Commands
#--------------------------------------------------------------------------------------
./actions/docker-run-web.sh