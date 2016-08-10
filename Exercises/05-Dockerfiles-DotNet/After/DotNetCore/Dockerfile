# NOTE: A project.lock.json file must be included, otherwise you will get the following error:
#       Project app does not have a lock file

# Build the image:
# docker build -t dotnet-helloweb .

# Create and run a container:
# docker run -d -p 5000:5000 --name dotnet-helloweb dotnet-helloweb

# Derive from base dotnet image
FROM microsoft/dotnet

MAINTAINER Anthony Sneed

# Set environment variables
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Staging"

# Copy files to app directory
COPY . /app

# Set working directory
WORKDIR /app

# Restore NuGet packages
RUN ["dotnet", "restore"]

# Open up port
EXPOSE 5000

# Run the app
ENTRYPOINT ["dotnet", "run"]