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

Console.Write("User> ");
var userInput = Console.ReadLine();

// Get the response
var chatCompletionOptions = new ChatCompletionsOptions(deploymentName, [
    new ChatRequestSystemMessage(prompt),
    new ChatRequestUserMessage(userInput)
]);
var chatCompletionResponse = await client.GetChatCompletionsAsync(chatCompletionOptions);

var response = chatCompletionResponse.Value.Choices[0].Message.Content;
Console.WriteLine("Assistant> " + response);