# Exercise: Mapping to Source Code

## Part A: Mapping static files to source with .NET Core

1. Open a terminal at the DotNetCore folder.
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

    - Open a browser and navigate to the following two pages:
        + <http://localhost:5000/hello.html>
      
2. Build the image using Docker client
    - Build the docker image, using -t to tag the image

    ```
    docker build -t dotnet-helloweb-static .
    ```

    - After building image, you can view the images
        + `docker images`
  
3. Create and run a docker container
    - Use `docker run` to create and start a container
    - Map app to the working directory
  
    ```
    docker run -d -p 5000:5000 --name dotnet-helloweb-static -v "${PWD}:/app" dotnet-helloweb-static
    ```

    - After running, you can view containers
        + `docker ps -a`
  
4. Run the app from a browser
    - Use localhost with port 5000 to open the web app
        + <http://localhost:5000/hello.html>

5. Change the content of the static HTML file
    - Then refresh the web browser
    - The new content should be displayed
    - Stop the container

## Part B: Mapping dynamic files to source with .NET Core Watch
    
1. Open a terminal at the DotNetCoreWatch folder.
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
    dotnet watch run
    ```

    - Open a browser and navigate to the following page:
        + <http://localhost:5000>

2. Change the content of the Index method on HomeController.
    - You should observe the web server restarted in the Terminal window.
    - Refresh the browser to see the new content displayed.

3. Build the docker image

    ```
    docker build -t dotnet-helloweb-watch .
    ```

4. Run the container.

    ```
    docker run -d -p 5000:5000 --name dotnet-helloweb-watch -v "${PWD}:/app" dotnet-helloweb-watch
    ```

5. Open a browser to view the web page.

6. Again change the content returned by HomeController
    - Refresh the browser to see the new content displayed

