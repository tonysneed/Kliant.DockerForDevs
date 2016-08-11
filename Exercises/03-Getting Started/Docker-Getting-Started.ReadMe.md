# Exercise: Getting Started with Docker

1. Install the Docker client for Mac OS X or Windows.
    - Go to docker.com and click Getting Started button
    - Install Docker on either a host or virtual machine

2. Verify the installation.
    - Open a command line and enter:

    ```
    docker version
    ```

3. Run the **hello-world** container.
    - Open the Docker QuickStart Terminal
    - Pull and run the container

    ```
    docker run hello-world
    ```

4. Show all containers.

    ```
    docker ps -a
    ```

5. Remove the container.

    ```
    docker rm [container id: first three characters]
    ```

6. List images.

    ```
    docker images
    ```

7. Remove the hello-world image.

    ```
    rmi hello-world
    ```

8. Pull down **nginx** image.

    ```
    docker pull nginx
    ```

9. Run the nginx image.

    ```
    docker run -d -p 80:80 --name web1 nginx
    ```

    - Open a browser to see the web server: <http://localhost>
    - If you are using Docker Toolbox, use docker-machine to
      get the IP address for the VM running under VirtualBox.
      + Then use IP address instead of localhost.

    ```
    docker-machine ip
    ```
    