# Build: docker build -f aspnetcore.dockerfile -t aspnetcore3 .

# Option 1: Legacy Linking
 
# docker run -d -p 27017:27017 --name my-mongo -v mongo-data:/data/db mongo
# docker run -d -p 3000:3000 --link my-mongo:my-mongodb --name mongoose -v $(pwd):/var/www mongoose
# docker run -d -p 5000:5000 --link mongoose:mongoose --name aspnetcore3 -v $(pwd):/app aspnetcore3

# Option 2: Bridge Network

# docker network create --driver bridge my_network
# docker run -d --net=my_network --name my-mongodb -v mongo-data:/data/db mongo
# docker run -d --net=my_network --name mongoose mongoose
# docker run -d -p 5000:5000 --net=my_network --name aspnetcore3 -v $(pwd):/app aspnetcore3

FROM microsoft/dotnet:latest

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