# Exercise: Work with Dockerfiles and Dockerize a .NET Core app

## Part A: Create an empty .NET Core web app

1. Install **Visual Studio Code** with C# and Docker extensions
    - Go to code.visualstudio.com
        + Download and install VS Code
    - From within VS Code, type Cmd+P, then ext
        + Install the C# extension
        + Install the extension for Dockerfile and Docker Compose support

2. Prepare your system for .NET Core
    - Mac:
        + To remove a prior version of .NET Core from Mac OS X, you can use this tool:

          <http://www.corecode.at/uninstallpkg>

        + Install prerequisites:

        ```
        brew update
        brew install openssl
        ln -s /usr/local/opt/openssl/lib/libcrypto.1.0.0.dylib /usr/local/lib/
        ln -s /usr/local/opt/openssl/lib/libssl.1.0.0.dylib /usr/local/lib/
        ```

    - Windows:
        + To remove a prior version of .NET Core, go to Programs and Features

3. Download and install the **.NET Core SDK Installer** for your OS from here:

    <https://www.microsoft.com/net/core>

    + Click on the "official installer" link to install the latest stable SDK.

4. Open a terminal in the Before/DotNetCore folder.
    - Restore packages
    
    ```
    dotnet restore
    ```

    - Build the app

    ```
    dotnet build
    ```

    - Run the app

    ```
    dotnet run
    ```

    - Open a browser and navigate to the following page:
        + <http://localhost:5000>
    
## Part B: Deploy the web app using Docker
    
1. Add a Dockerfile to the project with the following content:

    ```
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
    ```
  
2. Build the image using Docker client
    - Build the docker image, using -t to tag the image

    ```
    docker build -t dotnet-helloweb .
    ```

    - After building image, you can view the images
        + `docker images`
  
3. Create and run a docker container
    - Use `docker run` to create and start a container
  
    ```
    docker run -d -p 5000:5000 --name dotnet-helloweb dotnet-helloweb
    ```

    - After running, you can view containers
        + `docker ps -a`
  
4. Run the app from a browser
    - Use localhost with port 5000 to open the web app
        + <http://localhost:5000>

5. Start an additional container
    - Replace the port mapping: `-p 5001:5000`
    - Append 2 to the name
    - Run the web app: <http://localhost:5001>
    - See all the running containers: `docker ps`

6. If you wish, you may stop and remove both containers

    ```
    docker stop [container id: first three characters]
    docker rm [container id: first three characters]
    ```
