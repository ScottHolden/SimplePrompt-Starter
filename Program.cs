using Azure;
using Azure.AI.OpenAI;
using Azure.Identity;

string endpoint = "https://<fillthisin>.openai.azure.com/";
string deploymentName = "<fillthisin>";

// Set up out client
var credential = new DefaultAzureCredential(new DefaultAzureCredentialOptions {
    //TenantId = "aaa-bbb-ccc-ddd-eee", // Uncomment if using a tenant other than the default
});
var client = new OpenAIClient(new Uri(endpoint), credential);

// Set up our prompt and user message
var prompt = """
    You are a helpful AI.
    """.Trim();

var userInput = Console.ReadLine();

// Get the response
var chatCompletionOptions = new ChatCompletionsOptions(deploymentName, [
    new ChatRequestSystemMessage("""
    You are a developer assistant AI.
    Take the users business requirements and generate a Swagger specification implementing 5-10 endpoints.
    Respond with the Swagger specification as a json object and nothing else.
    """),
    new ChatRequestUserMessage("A doctors reservation system")
]);
var chatCompletionResponse = await client.GetChatCompletionsAsync(chatCompletionOptions);

var response = chatCompletionResponse.Value.Choices[0].Message.Content;
Console.WriteLine(response);