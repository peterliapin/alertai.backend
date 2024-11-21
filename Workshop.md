# GitHub Copilot Workshop Practice

## Basic Use Cases

### Task 1 - Explain what ConfigureConventions method does in Program.cs

[Program.cs](./src/Suggestio.Api/Program.cs)

### Task 2 - Add one more implementation for IEmailService to support attachments

[IEmailService.cs](./src/Suggestio.Api/Interfaces/IEmailService.cs)

### Task 3 - Implement new method in EmailService

[EmailService.cs](./src/Suggestio.Api/Services/EmailService.cs)

### Task 4 - Write the code that will go to GPT and execute prompt

// executes prompt taking maxTokens parameter into account using gpt-4o model and ChatClient
// be sure to use latest version 2.0.0 of OpenAI library

```
var client = new ChatClient(model: "gpt-4o", openAIConfig.ApiKey);

var options = new ChatCompletionOptions()
{
    MaxTokens = maxTokens
};

var messages = new List<UserChatMessage>
{
    new UserChatMessage(prompt)
};

var completion = await client.CompleteChatAsync(messages, options);

return completion.Value.Content[0].Text;
```

### Task 5 - Implement new send-ideas API method in TopicController prividing context in comments

[TopicsController.cs](./src/Suggestio.Api/Controllers/TopicsController.cs)

```
// send-ideas API method accepting array of topic and sending ideas for all topics using SendIdea method
```

```
/// <summary>
/// Sends multiple ideas for specific topics.
/// </summary>
/// <param name="ids">The IDs of the topics.</param>
/// <returns>An IActionResult indicating the result of the operation.</returns>
[HttpPost("{id}/send-ideas")]
[SwaggerOperation(Summary = "Sends multiple ideas for specific topics")]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public async Task<IActionResult> SendIdeas(Guid[] ids)
{
    foreach (var id in ids)
    {
        await SendIdea(id);
    }

    return Ok();
}
```

### Task 6 - Find out if errors handling should be added on the controller level using Q&A mode

```
// q: Is it a good idea to have errors handling logic on the controller level or are there alternative approaches to avoid copy-pasting try/catch/finally in all API methods?

// a: 
```

### Task 7 - Find out if there are any naming inconsistencies using Chat

### Task 8 - Fix naming convention inconsistency in IdeaController

[IdeaController.cs](./src/Suggestio.Api/Controllers/IdeaController.cs)

### Task 9 - Update Readme to include information about migrations

Update readme to show how to add and run migrations locally. Note that we should run migrations before we do dotnet run. Please also add a new section for developers explaining how to add new migrations and where they are located.

### Task 10 - API documentation

[TopicsController.cs](./src/Suggestio.Api/Controllers/TopicsController.cs)

Sync commenting style and the way how we define SwaggerOperation and ProducesResponseType from TopicsController to other two controllers.

### Task 11 - Commit changes and use AI generate commit message


## Advanced Use Cases

### Task 1 - Show how @workspace, /explain, /fix, /new and /tests commands work.

### Task 2 - Cover TopicsController with unit-tests

Generate tests to cover #file:TopicsController.cs, take into account that instead of real EmailService we need to use #file:TestEmailService.cs. Use #file:IdeasControllerTests.cs as a source of inspiration on how to do the rest.

### Task 2 - Generate command to copy files over ssh

Generate a command to copy all files from the current folder to /home/user/target folder on mydomain.com server over ssh using myuser as login.

### Task 3 - Find out why application crash on start

[Program.cs](./src/Suggestio.Api/Program.cs)