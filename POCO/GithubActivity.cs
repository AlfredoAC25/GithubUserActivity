using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json.Serialization;

namespace GithubUserActivity.POCO
{
    internal class GithubActivity
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
        [JsonPropertyName("actor")]
        public Actor Actor { get; set; } = new();
        [JsonPropertyName("repo")]
        public Repo Repo { get; set; } = new();
        [JsonPropertyName("payload")]
        public Payload Payload { get; set; } = new();
        [JsonPropertyName("public")]

        public bool? Public { get; set; }
        [JsonPropertyName("created_at")]
        public DateTime createdAt { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} | Type: {Type} | Actor: {Actor} | Repo {Repo} | Payload {Payload} | Public {Public} | CreatedAt {createdAt}";
        }
    }

    public class Actor
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("login")]

        public string Login { get; set; } = string.Empty;

        [JsonPropertyName("display_login")]
        public string DisplayLogin { get; set; } = string.Empty;
        [JsonPropertyName("url")]

        public string Url { get; set; } = string.Empty;

        [JsonPropertyName("avatar_url")]
        public string AvatarUrl { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"ID: {Id} | DisplayLogin: {DisplayLogin} | Url: {Url} | AvatarUrl {AvatarUrl}";
        }
    }

    public class Repo
    {
        [JsonPropertyName("Id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
        public override string ToString()
        {
            return $"Id {Id} | Name {Name} | Url {Url}";
        }
    }

    public class Payload
    {
        [JsonPropertyName("action")]
        public string? Action { get; set; }
        [JsonPropertyName("ref")]
        public string? Ref { get; set; }

        [JsonPropertyName("ref_type")]
        public string? RefType { get; set; }

        [JsonPropertyName("repository_id")]
        public long? RepositoryId { get; set; }

        [JsonPropertyName("push_id")]
        public long? PushId { get; set; }
        [JsonPropertyName("size")]
        public string? Head { get; set; }
        [JsonPropertyName("before")]

        public string? Before { get; set; }
        public override string ToString()
        {
            return $"Ref {Ref} | RefType {RefType} | RepositoryId {RepositoryId} | PushId {PushId} | Head {Head} | Before {Before}";
        }
    }
}
