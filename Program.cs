using System.CommandLine;
using System.Net.Http.Headers;

using HttpClient client = new();
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(
    new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
client.DefaultRequestHeaders.Add("User-Agent", "GitHubUserActivity-App");

var githubAccount = new Argument<string>("github-account")
{
    Description = "Github name account"
};
var githubActivity = new Command("github-activity", "Shows the activity from a Github´s account")
{
    githubAccount
};

githubActivity.SetAction(async parseResult =>
{
    string? account = parseResult.GetValue(githubAccount);

    if(!string.IsNullOrEmpty(account))
        await ProcessRepositoriesAsync(client, account);
    else
        Console.WriteLine("Please provide a valid Github account name.");
    return 0;
});

var rootCommand = new RootCommand("Github User Activity Command-Line Tool");
rootCommand.Subcommands.Add(githubActivity);

return rootCommand.Parse(args).Invoke();

static async Task ProcessRepositoriesAsync(HttpClient client, string account)
{
    Console.WriteLine($"Fetching activity for GitHub account: {account}");

    var json = await client.GetStringAsync(
         $"https://api.github.com/users/{account}/events");

    Console.WriteLine(json);
}