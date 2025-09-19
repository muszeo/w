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
export SRC_PROJECT=../../../W.Api/
export DNC_FRAMEWORK=net6.0
export DNC_CONFIGURATION=Release
export PUBLISH_TARGET=./web/publish
#--------------------------------------------------------------------------------------
# Execute dotnet Commands
#--------------------------------------------------------------------------------------
./actions/dotnet-publish.sh
