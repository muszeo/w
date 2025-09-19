#!/usr/bin/env bash
#--------------------------------------------------------------------------------------
# Write Console Header
#--------------------------------------------------------------------------------------
echo "======================================================================================="
echo " "
echo "  Push:    " $PRODUCT_DOMAIN "/" $PRODUCT_NAME ":" $VERSION
echo "  To:      " $AWS_REPO "/" $PRODUCT_NAME ":" $VERSION
echo "  Blame:   " $AUTHOR
echo " "
echo "  Note: 1. Use this script to push the api-web Docker image to                         "
echo "           the MyTrucking Amazon ECR docker registry.                                  "
echo "        2. To use this script you will need to setup your Amazon Web Services 'config' "
echo "           and 'credentials' files in your user root '/.aws' folder.                   "
echo " "
echo "======================================================================================="
#--------------------------------------------------------------------------------------
# Start Execution
#--------------------------------------------------------------------------------------
echo "Login to AWS Elastic Container Registry (ECR) for MyTrucking subscription..."
aws ecr get-login-password --region ap-southeast-2 | docker login --username AWS --password-stdin $AWS_REPO
echo "Tag docker image with AWS ECR tag..."
docker image tag $PRODUCT_DOMAIN/$PRODUCT_NAME:$VERSION $AWS_REPO/$PRODUCT_NAME:$VERSION
echo "Push docker image to AWS ECR..."
docker push $AWS_REPO/$PRODUCT_NAME:$VERSION
echo "Remove docker image locally..."
docker rmi $AWS_REPO/$PRODUCT_NAME:$VERSION
echo "======================================================================================="
echo " < < < ...Done"
echo "======================================================================================="