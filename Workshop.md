# GitHub Copilot Workshop Practice

## Basic Use Cases

### Task 1 - Explain what ConfigureConventions method does in Program.cs

[Program.cs](./src/AlertAI.Api/Program.cs)

### Task 2 - Add one more implementation for IEmailService to support attachments

[IEmailService.cs](./src/AlertAI.Api/Interfaces/IEmailService.cs)

### Task 3 - Implement new method in EmailService

[EmailService.cs](./src/AlertAI.Api/Services/EmailService.cs)

### Task 4 - Implement new send-ideas API method in TopicController

[TopicsController.cs](./src/AlertAI.Api/Controllers/TopicsController.cs)

### Task 5 - Find out if errors handling should be added on the controller level using Q&A mode

```
// q: Is it a good idea to have errors handling logic on the controller level or are there alternative approaches to avoid copy-pasting try/catch/finally in all API methods?

// a: 
```

### Task 6 - Find out if there are any naming inconsistencies using Chat

### Task 7 - Fix naming convention inconsistency in IdeaController

[IdeaController.cs](./src/AlertAI.Api/Controllers/IdeaController.cs)

## Task 8 - Update Readme to include information about migrations

Update readme to show how tp add and run migrations locally. Note that we should run migrations before we start. Add new  section for developers explaining how to add new migrations and where they are located.

# Exerceise 2 - API documentation

[TopicsController.cs](./src/AlertAI.Api/Controllers/TopicsController.cs)

Add SwaggerOperation and ProducesResponseType attribute to all API method similar to existing SendIdea method.

# Exerceise 2 - Put migrations into a different folder


# Exerceise 3 - Write the code that will go to GPT and execute prompt


# Exerceise 4 - Write a new controller to send multiple ideas


## Advanced Use Cases

### Task 1 - 

### Task 2 - Generate command to copy files over ssh

Generate a command to copy all files from the current folder to /home/user/target folder on mydomain.com server over ssh using myuser as login.

### Task 3 - Find out why application crash on start

[Program.cs](./src/AlertAI.Api/Program.cs)
