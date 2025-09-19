#!/usr/bin/env bash
#--------------------------------------------------------------------------------------
# Parameters
#--------------------------------------------------------------------------------------
export AUTHOR="Martin Hunter"
export PRODUCT_DOMAIN="mytrucking"
export VERSION="1.0.3"
export PRODUCT_NAME="metric-api-web"
export AWS_REPO="439722369110.dkr.ecr.ap-southeast-2.amazonaws.com"
#--------------------------------------------------------------------------------------
# Run
#--------------------------------------------------------------------------------------
./actions/docker-push.sh