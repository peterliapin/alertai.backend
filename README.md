# AlertAI

This is a .NET 8 backend application called AlertAI. It serves as a backend for the GPT-based AI assistant and provides functionality to send notifications based on user preferences.

## Project Structure

The project has the following files:

- `src/AlertAI.Api/Controllers/NotificationController.cs`: This file contains the controller `NotificationController` which handles the endpoints related to notifications.

- `src/AlertAI.Api/Controllers/UserController.cs`: This file contains the controller `UserController` which handles the endpoints related to users.

- `src/AlertAI.Api/Controllers/TopicController.cs`: This file contains the controller `TopicController` which handles the endpoints related to topics.

- `src/AlertAI.Api/Controllers/ScheduleController.cs`: This file contains the controller `ScheduleController` which handles the endpoints related to schedules.

- `src/AlertAI.Api/Program.cs`: This file is the entry point of the API application.

- `src/AlertAI.Api/Startup.cs`: This file contains the configuration for the API application.

- `src/AlertAI.Api/AlertAI.Api.csproj`: This file is the project file for the API application.

- `src/AlertAI.Core/Models/User.cs`: This file defines the `User` model class.

- `src/AlertAI.Core/Models/Topic.cs`: This file defines the `Topic` model class.

- `src/AlertAI.Core/Models/Schedule.cs`: This file defines the `Schedule` model class.

- `src/AlertAI.Core/Services/NotificationService.cs`: This file contains the `NotificationService` class which handles the logic for sending notifications.

- `src/AlertAI.Core/Services/UserService.cs`: This file contains the `UserService` class which handles the logic for user-related operations.

- `src/AlertAI.Core/Services/TopicService.cs`: This file contains the `TopicService` class which handles the logic for topic-related operations.

- `src/AlertAI.Core/Services/ScheduleService.cs`: This file contains the `ScheduleService` class which handles the logic for schedule-related operations.

- `src/AlertAI.Core/AlertAI.Core.csproj`: This file is the project file for the core logic of the application.

- `src/AlertAI.Infrastructure/Data/NotificationDbContext.cs`: This file contains the `NotificationDbContext` class which represents the database context for notifications.

- `src/AlertAI.Infrastructure/Data/Migrations`: This directory contains the database migration files.

- `src/AlertAI.Infrastructure/Repositories/UserRepository.cs`: This file contains the `UserRepository` class which handles the database operations for users.

- `src/AlertAI.Infrastructure/Repositories/TopicRepository.cs`: This file contains the `TopicRepository` class which handles the database operations for topics.

- `src/AlertAI.Infrastructure/Repositories/ScheduleRepository.cs`: This file contains the `ScheduleRepository` class which handles the database operations for schedules.

- `src/AlertAI.Infrastructure/Services/EmailService.cs`: This file contains the `EmailService` class which handles sending emails using the SendGrid service.

- `src/AlertAI.Infrastructure/Services/PushNotificationService.cs`: This file contains the `PushNotificationService` class which handles sending push notifications.

- `src/AlertAI.Infrastructure/AlertAI.Infrastructure.csproj`: This file is the project file for the infrastructure layer of the application.

- `src/AlertAI.Authentication/OAuth/GoogleAuthService.cs`: This file contains the `GoogleAuthService` class which handles OAuth authentication using Google.

- `src/AlertAI.Authentication/OAuth/AppleAuthService.cs`: This file contains the `AppleAuthService` class which handles OAuth authentication using Apple.

- `src/AlertAI.Authentication/OAuth/FacebookAuthService.cs`: This file contains the `FacebookAuthService` class which handles OAuth authentication using Facebook.

- `src/AlertAI.Authentication/AlertAI.Authentication.csproj`: This file is the project file for the authentication layer of the application.

- `tests/AlertAI.Api.Tests/NotificationControllerTests.cs`: This file contains the unit tests for the `NotificationController` class.

- `tests/AlertAI.Api.Tests/UserControllerTests.cs`: This file contains the unit tests for the `UserController` class.

- `tests/AlertAI.Api.Tests/TopicControllerTests.cs`: This file contains the unit tests for the `TopicController` class.

- `tests/AlertAI.Api.Tests/ScheduleControllerTests.cs`: This file contains the unit tests for the `ScheduleController` class.

- `tests/AlertAI.Core.Tests/NotificationServiceTests.cs`: This file contains the unit tests for the `NotificationService` class.

- `tests/AlertAI.Core.Tests/UserServiceTests.cs`: This file contains the unit tests for the `UserService` class.

- `tests/AlertAI.Core.Tests/TopicServiceTests.cs`: This file contains the unit tests for the `TopicService` class.

- `tests/AlertAI.Core.Tests/ScheduleServiceTests.cs`: This file contains the unit tests for the `ScheduleService` class.

- `tests/AlertAI.Infrastructure.Tests/NotificationDbContextTests.cs`: This file contains the unit tests for the `NotificationDbContext` class.

- `tests/AlertAI.Infrastructure.Tests/UserRepositoryTests.cs`: This file contains the unit tests for the `UserRepository` class.

- `tests/AlertAI.Infrastructure.Tests/TopicRepositoryTests.cs`: This file contains the unit tests for the `TopicRepository` class.

- `tests/AlertAI.Infrastructure.Tests/ScheduleRepositoryTests.cs`: This file contains the unit tests for the `ScheduleRepository` class.

- `README.md`: This file contains the documentation for the project.
```

This README.md file provides an overview of the project structure and the purpose of each file in the project. It serves as a reference for developers working on the project.