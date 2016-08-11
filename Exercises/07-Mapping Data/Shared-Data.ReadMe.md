# Exercise: Mapping to Shared Data

## Part A: Create Mongo containers without mounting data volume

1. Pull down the official **mongo** image from DockerHub
    - See the mongo page for more info: https://hub.docker.com/_/mongo/
    - Execute the docker `run` command to pull the image and create a container
        + Supply the `--name` parameter to use with linking from other containers
        + Specify a volume on the Linux host for the database and log files

    ```
    docker run -d -p 27017:27017 --name mongo1 mongo
    ```

2. Install MongoChef and use it to import data
    - http://3t.io/mongochef
    - Open MongoChef and create a new connection
        + For the server, enter: localhost
    - Click the Import button and select `customers.json` from the Data folder
    - View customer data

3. Stop the running container.

    ```
    docker stop mongo1
    ```

4. Create another container from the same image

    ```
    docker run -d -p 27017:27017 --name mongo2 mongo
    ```

5. Use MongoChef to view customer data
    - Notice that the data previously imported is *not* present
        + This is because data is not shared among containers
    - When done you can stop and remove the two containers

## Part B: Create Mongo containers with mounting data volume

1. Create a mongo container with a mounted data volume

    ```
    docker run -d -p 27017:27017 --name my-mongo -v mongo-data:/data/db mongo
    ```

2. Inspect the data volume
    - Search for the Mounts section
    - Note the Source of the mongo-data volume: **"/var/lib/docker/volumes/mongo-data/_data"**

    ```
    docker inspect my-mongo
    ```

3. Stop the my-mongo container

    ```
    docker stop my-mongo
    ```

4. Import customer data using MongoChef

5. You can add another container with a different name.
    - Notice that the previously imported data is still available
        + This is because data is mapped to a common directory on the VM

    ```
    docker run -d -p 27017:27017 --name my-mongo2 -v mongo-data:/data/db mongo
    ```

    - When you're done, go ahead and remove the second container.

    ```
    docker rm -f my-mongo2
    ```
   