#!/usr/bin/env bash
#--------------------------------------------------------------------------------------
# Write Console Header
#--------------------------------------------------------------------------------------
echo "======================================================================================="
echo " "
echo "  Deploy:  " $PRODUCT_NAME
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
echo " > > PRODUCT_DOMAIN   = " $PRODUCT_DOMAIN
echo " > > PRODUCT_NAME     = " $PRODUCT_NAME
echo " > > VERSION          = " $VERSION
echo " > > RELEASE          = " $RELEASE
echo " > > SRC              = " $SRC
echo " > > HOST_PORT        = " $HOST_PORT
echo " > > GUEST_PORT       = " $GUEST_PORT
echo " > > DATABASE_USER    = " $DATABASE_USER
echo " > > DATABASE_PWD     = " $DATABASE_PWD
echo " > > DATABASE_DB      = " $DATABASE_DB
echo " "
cd "$SRC"
# The below run statement is for POSTGRES DB.
# export RUN_STATEMENT="docker run -d -p "$HOST_PORT":"$GUEST_PORT" --name "$PRODUCT_NAME" -e POSTGRES_USER="$DATABASE_USER" -e POSTGRES_PASSWORD="$DATABASE_PWD" -e POSTGRES_DB="$DATABASE_DB" "$PRODUCT_DOMAIN"/"$PRODUCT_NAME":"$VERSION
# The below run statement is for MySQL DB.
export RUN_STATEMENT="docker run -d -p "$HOST_PORT":"$GUEST_PORT" --name "$PRODUCT_NAME" --log-driver json-file --log-opt mode=non-blocking --log-opt max-buffer-size=4m -e MYSQL_ROOT_HOST="'%'" -e MYSQL_ROOT_PASSWORD="$DATABASE_PWD" -e MYSQL_USER="$DATABASE_USER" -e MYSQL_PASSWORD="$DATABASE_PWD" -e MYSQL_DATABASE="$DATABASE_DB" "$PRODUCT_DOMAIN"/"$PRODUCT_NAME":"$VERSION
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