#!/bin/bash

echo "Building app..."
dotnet build

echo "Building Docker image..."
docker build -t my-api .

echo "Running container..."
docker stop my-api || true
docker rm my-api || true
docker run -d -p 8080:80 --name SchoolAPI