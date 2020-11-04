# Course Library
![Build & Tests](https://github.com/ktutak1337/CourseLibrary/workflows/Build%20&%20Tests/badge.svg?branch=main)
[![GitHub license](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ktutak1337/CourseLibrary/blob/main/LICENSE.md)

This is a sample project created by following the principles of Clean Architecture and Domain-driven design approach.

# How to start the solution?
#### locally
The API can be started locally within `/src/your_project_name.Api` directory *(by default it will be available under `https://localhost:5001`)* using the following command:
``` csharp
~$ dotnet run
```
or by running `./scripts/start.sh` shell script in the **main directory**.

#### Docker
You can also run the API using Docker:
1. Make sure you are in the **main directory** and run the following command to build your image:
``` bash
~$ docker build --tag tag_name .
```
2. Run the following command to start a container based on your new image:
``` bash
~$ docker run -p 5001:5001 -d --name container_name tag_name
```
&nbsp;&nbsp;&nbsp;&nbsp;\**to run the container in the background use `-d` options.*

If you want to start the entire infrastructure (API, MongoDB). The easiest way to run it is by using `docker-compose`. For this case, navigate to `/scripts/compose` and execute the following command:
``` bash
~$ docker-compose -f script_name.yml up -d
```
&nbsp;&nbsp;&nbsp;&nbsp;\**to run in the background use `-d` options.*

Or just install the entire infrastructure locally on your machine.

# Give a star! :star:
If you like this project, learned something or you are using it to start your solution, please give it a star. Thanks!
