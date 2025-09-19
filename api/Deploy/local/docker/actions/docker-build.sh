#!/usr/bin/env bash
#--------------------------------------------------------------------------------------
# Write Console Header
#--------------------------------------------------------------------------------------
echo "======================================================================================="
echo " "
echo "  Build:   " $PRODUCT_NAME
echo "  To:       Local Machine (Docker)"
echo "  Blame:   " $AUTHOR
echo " "
echo "======================================================================================="
#--------------------------------------------------------------------------------------
# Start Execution
#--------------------------------------------------------------------------------------
echo " STARTING EXECUTION"
echo " "
echo " > > AUTHOR           = " $AUTHOR 
echo " > > CONTACT          = " $CONTACT
echo " "
echo " > > PRODUCT_DOMAIN   = " $PRODUCT_DOMAIN 
echo " > > PRODUCT_NAME     = " $PRODUCT_NAME 
echo " > > VERSION          = " $VERSION 
echo " > > SRC              = " $SRC
echo " "
echo "======================================================================================="
echo " > > > Running docker commands..."
echo "======================================================================================="
cd "$SRC"
docker stop $PRODUCT_NAME
docker rm -v $PRODUCT_NAME
docker rmi $PRODUCT_DOMAIN/$PRODUCT_NAME:$VERSION
docker build --no-cache $DOCKER_PLATFORM --tag=$PRODUCT_DOMAIN/$PRODUCT_NAME:$VERSION .
echo "======================================================================================="
echo " "
echo " 	Done"
echo " "
echo "======================================================================================="