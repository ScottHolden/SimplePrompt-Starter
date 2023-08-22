using Azure;
using Azure.AI.OpenAI;
using Azure.Identity;

string endpoint = "https://<fillthisin>.openai.azure.com/";
string deploymentName = "<fillthisin>";
var credential = new DefaultAzureCredential();

var client = new OpenAIClient(new Uri(endpoint), credential);

var prompt = """

""".Trim();

// Sample emails can be found in email01.txt and email02.txt, or you can cretae your own!

Response<Completions> response = await client.GetCompletionsAsync(deploymentName, prompt);

foreach (Choice choice in response.Value.Choices)
{
    // Output is up to you!
}
