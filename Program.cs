using System.CommandLine;
using System.Net.Http.Headers;
using System.Text.Json;
using GithubUserActivity.POCO;

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
    List<GithubActivity> githubActivities = new List<GithubActivity>();

    var json = await client.GetStringAsync(
         $"https://api.github.com/users/{account}/events");

    if(!string.IsNullOrEmpty(json))
        githubActivities = JsonSerializer.Deserialize<List<GithubActivity>>(json) ?? new List<GithubActivity>();

    foreach (var activity in githubActivities)
    {
        switch (activity.Type)
        {
            case "PushEvent":
                Console.WriteLine($"- pushed commit to {activity.Repo.Name}");
                break;
            case "PullRequestEvent":
                Console.WriteLine($"- {activity.Payload.Action} pull request in {activity.Repo.Name}");
                break;
            case "IssuesEvent":
                Console.WriteLine($"- issue {activity.Payload.Action} in {activity.Repo.Name}");
                break;
            case "PullRequestReviewEvent":
                Console.WriteLine($"- pull request review {activity.Payload.Action} in {activity.Repo.Name}");
                break;
            case "PullRequestReviewCommentEvent":
                Console.WriteLine($"- pull request review comment {activity.Payload.Action} in {activity.Repo.Name}");
                break;
            case "CreateEvent":
                Console.WriteLine($"- created repo {activity.Repo.Name}");
                break;
            case "DeleteEvent":
                Console.WriteLine($"- deleted {activity.Repo.Name}");
                break;
            case "WatchEvent":
                Console.WriteLine($"- starred a repository: {activity.Repo.Name}");
                break;
            default:
                //activity.Type = $"Other Event: {activity.Type}";
                break;
        }
    }
}