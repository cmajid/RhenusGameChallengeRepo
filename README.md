# RhenusGameChallengeRepo

This repository contains a coding challenge solution for creating a simple REST API using .NET and C#.

## Table of Contents

- [Installation](#installation)
  - [Running with Docker Image](#running-with-docker-image)
  - [Cloning the Repository](#cloning-the-repository)
  - [Running with `dotnet` Command](#running-with-dotnet-command)
- [Usage](#usage)
  - [Accessing API Documentation](#accessing-api-documentation)
- [Testing](#testing)
- [Game Rules](#game-rules)

## Installation

### Running with Docker Image

To run the project using Docker, follow these steps:

1. Make sure Docker is installed on your system.
2. Run the following command:

```bash
docker run -p 5500:5500 \
    --name rhenus-game-challenge  \
    -e ASPNETCORE_HTTP_PORTS=5500 \
    -e ASPNETCORE_ENVIRONMENT=Development \
    cmajid/rhenus-game-challenge 
```

3. Open the following URL in your browser:

```
http://localhost:5500/swagger/index.html
```

### Cloning the Repository

To clone the repository, use the following command:

```bash
git clone https://github.com/cmajid/RhenusGameChallengeRepo
```

### Running with `dotnet` Command

To run the project using the `dotnet` command, navigate to the `Rhenus/RhenusGameChallenge` folder and execute the following command:

```bash
cd RhenusGameChallengeRepo/Rhenus/Rhenus.GameChallenge
dotnet run
```

## Usage

### Accessing API Documentation

Once the application is running, you can access the Swagger documentation by navigating to the following URL in your browser:

```
http://localhost:5500/swagger/index.html
```

This documentation provides details about the available endpoints, request parameters, and responses.

## Testing

Unit tests are included in the project to ensure the reliability of the code. To run the tests, navigate to the `Rhenus\Tests` folder and execute the following command:

```bash
cd RhenusGameChallengeRepo/Rhenus/Tests
dotnet test
```

## Game Rules

- This is a game of chance in which a random number between 0 - 9 is to be generated
- A player will predict the random number
-  The player has a starting account of 10,000 points and can wager them on a prediction which they will either win or lose
- Any number of points can be wagered
- If the player is correct, they win 9 times their stake
- If the player is incorrect, they lose their stake