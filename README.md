# Docker
## Getting the Docker Image
I have created a docker image that you can pull down with:
`docker pull notsica/cleancode:v1`

or you can just use this to install and run it: 
 `docker run -it notsica/cleancode:v1`

You can also create your own docker image locally using the included Dockerfile when in the same directory as it with:
`docker build -t notsica/cleancode:v1 .`

## Running the Docker Image 
Use `docker run -it notsica/cleancode:v1` to run the container in the terminal you typed it in.

# Project
I rewrote the project in .NET 8 as it was previously running on .NET Framework v4.7.2. It's likely that the issues with the application arose from that, so if you want to ignore any docker stuff and just run the tests again. They should work properly this time. 
