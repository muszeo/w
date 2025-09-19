#!/usr/bin/env bash
clear
echo "======================================================================================="
echo " "
echo " INTRODUCTION"
echo " "
echo " MYTRUCKING CACHE SERVICE WEB API COMPONENT - DEVELOPMENT & TEST"
echo " "
echo " This script provisions the Web API and DB using dotnet and Docker on your local machine."
echo " "
echo " By the end of the script's execution, the following should be provisioned:"
echo " "
echo " 1. Database (MySQL, accessible on localhost port 3306)"
echo " 2. Web (ASP.NET 6.0 MVC, accessible on localhost port 39803)"
echo " "
echo " Prerquisites that YOU WILL NEED TO INSTALL for this script to operate are as follows:"
echo " "
echo " 1. Docker 20+ (https://www.docker.com/products/docker-desktop)"
echo " 2. Microsoft .NET 6.0 Runtime & SDK (https://dotnet.microsoft.com/download/)"
echo " "
echo "======================================================================================="
# Set Execute Permissions
chmod +x actions/docker-build.sh
chmod +x actions/docker-run-web.sh
chmod +x actions/docker-run-db.sh
chmod +x actions/dotnet-publish.sh
chmod +x build-docker-web.sh
chmod +x build-docker-db.sh
chmod +x run-docker-web.sh
chmod +x run-docker-db.sh
chmod +x publish-web.sh
chmod +x publish-db.sh
# Publish Web and DB
./publish-db.sh
./publish-web.sh
# Build Docker Images
./build-docker-db.sh
./build-docker-web.sh
# Run Docker Images
./run-docker-db.sh
./run-docker-web.sh