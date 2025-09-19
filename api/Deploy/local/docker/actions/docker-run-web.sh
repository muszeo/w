#!/usr/bin/env bash
#--------------------------------------------------------------------------------------
# Write Console Header
#--------------------------------------------------------------------------------------
echo "======================================================================================="
echo " "
echo "  Run:     " $PRODUCT_NAME
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
echo " > > RELEASE          = " $RELEASE
echo " > > SRC              = " $SRC
echo " > > HOST_PORT        = " $HOST_PORT
echo " > > GUEST_PORT       = " $GUEST_PORT
echo " > > ENVIRONMEMT      = " $APP_ENVIRONMENT
echo " "
cd "$SRC"
export RUN_STATEMENT="docker run -d -p "$HOST_PORT":"$GUEST_PORT" --name "$PRODUCT_NAME" --log-driver json-file --log-opt mode=non-blocking --log-opt max-buffer-size=4m -e ASPNETCORE_ENVIRONMENT="$APP_ENVIRONMENT" -e ASPNETCORE_URLS=http://*:80 "$PRODUCT_DOMAIN"/"$PRODUCT_NAME":"$VERSION
echo "======================================================================================="
echo " > > > Running docker commands:"
echo " "
echo $RUN_STATEMENT
echo " "
echo "======================================================================================="
docker stop $PRODUCT_NAME
docker rm -v $PRODUCT_NAME
$RUN_STATEMENT
echo "======================================================================================="
echo " "
echo " 	Done"
echo " "
echo "======================================================================================="