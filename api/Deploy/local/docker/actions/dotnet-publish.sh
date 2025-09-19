#!/usr/bin/env bash
#--------------------------------------------------------------------------------------
# Write Console Header
#--------------------------------------------------------------------------------------
echo "======================================================================================="
echo " "
echo "  Publish: " $PRODUCT_NAME
echo "  To:       Local Machine (" $PUBLISH_TARGET ")"
echo "  Blame:   " $AUTHOR
echo " "
echo "======================================================================================="
#--------------------------------------------------------------------------------------
# Start Execution
#--------------------------------------------------------------------------------------
echo " STARTING EXECUTION"
echo " "
echo " > > AUTHOR            = " $AUTHOR 
echo " > > CONTACT           = " $CONTACT 
echo " "
echo " > > PRODUCT_DOMAIN    = " $PRODUCT_DOMAIN 
echo " > > PRODUCT_NAME      = " $PRODUCT_NAME 
echo " > > VERSION           = " $VERSION 
echo " > > RELEASE           = " $RELEASE
echo " > > SRC_PROJECT       = " $SRC_PROJECT
echo " > > DNC_FRAMEWORK     = " $DNC_FRAMEWORK
echo " > > DNC_CONFIGURATION = " $DNC_CONFIGURATION
echo " > > PUBLISH_TARGET    = " $PUBLISH_TARGET
echo " "
export RUN_STATEMENT="dotnet publish --framework "$DNC_FRAMEWORK" --configuration "$DNC_CONFIGURATION" --output \""$PUBLISH_TARGET"\" \""$SRC_PROJECT"\""
echo "======================================================================================="
echo " > > > Running dotnet commands:"
echo " "
echo $RUN_STATEMENT
echo " "
echo "======================================================================================="
$RUN_STATEMENT
#dotnet publish --framework $DNC_FRAMEWORK --configuration $DNC_CONFIGURATION --output "$PUBLISH_TARGET" "$SRC_PROJECT"
echo "======================================================================================="
echo " "
echo " 	Done"
echo " "
echo "======================================================================================="