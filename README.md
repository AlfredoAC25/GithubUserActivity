# Githubctivity

A simple C# command-line application that retrieves GitHub user activity using the GitHub API.

## Content table
- [Features](#Features)
- [Requirements](#Requirements)
- [Installation](#Installation)
- [Usage](#Usage)
- [Project Roadmap](#ProjectRoadmap)

## Features
Events you can fetch from user
- ✅PushEvent
- ✅PullRequestEvent
- ✅IssuesEvent
- ✅PullRequestReviewEvent
- ✅PullRequestReviewCommentEvent
- ✅CreateEvent
- ✅DeleteEvent
- ✅WatchEvent
- ✅ForkEvent
- ✅DiscussionEvent

## Requirements
- .NET SDK: `10.0`
- SO: Windows / Linux / macOS

## Installation
Clone and install dependencies:

```bash
git clone git@github.com:AlfredoAC25/GithubUserActivity.git
dotnet restore
```

## Usage
To fetch username activity
```bash
dotnet run github-activity [username]
```

## ProjectRoadmap
This project is part of a set of practice projects from the C# roadmap.

https://roadmap.sh/projects/github-user-activity

