#!/bin/bash
set -e  # Exit immediately if a command exits with a non-zero status
cd /app  # Change to the root folder
dotnet test --no-build --logger:trx;LogFileName=testResults.trx
echo "Tests completed."

if [ $? -ne 0 ]; then
  echo "Unit tests failed."
  exit 1
fi

cd /app/build  # Change to the build directory for runtime
