# AlertAI
This repository contains the source code for the AlertAI project.

## Prerequisites

Before running the project and tests locally, make sure you have the following prerequisites installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or later)
- [Visual Studio Code](https://code.visualstudio.com/) (optional)
- [Docker](https://www.docker.com/) (optional, for containerized deployment)

## Getting Started

To get started with the AlertAI project, follow these steps:

1. Clone this repository to your local machine.
2. Open the `AlertAI.sln` solution file in Visual Studio or your preferred code editor.

## Running the Project

To run the AlertAI project locally, follow these steps:

1. Open a terminal or command prompt.
2. Navigate to the `src/AlertAI.Api` directory.
3. Run the following command to restore dependencies:

    ```shell
    dotnet restore
    ```

4. Run the following command to build the project:

    ```shell
    dotnet build
    ```

5. Run the following command to apply migrations:

    ```shell
    dotnet ef database update
    ```

6. Run the following command to start the application:

    ```shell
    dotnet run
    ```

    The application will start and listen for incoming requests.

7. Open your web browser and navigate to `http://localhost:5298` to access the application.

## Adding Migrations

To add migrations to the AlertAI project, follow these steps:

1. Open a terminal or command prompt.
2. Navigate to the `src/AlertAI.Api` directory.
3. Run the following command to add migrations:

    ```shell
    dotnet ef migrations add migration_name
    ```

    This will create a migration based on your current database context.

4. Run the following command to apply the migrations to the database:

    ```shell
    dotnet ef database update
    ```

    This will apply the pending migrations to the database.

## Running the Tests

To run the tests for the AlertAI project locally, follow these steps:

1. Open a terminal or command prompt.
2. Navigate to the `tests/AlertAI.Api.Tests` directory.
3. Run the following command to restore dependencies:

    ```shell
    dotnet restore
    ```

4. Run the following command to build the tests:

    ```shell
    dotnet build
    ```

5. Run the following command to execute the tests:

    ```shell
    dotnet test
    ```

    The test runner will execute all the tests and display the results.