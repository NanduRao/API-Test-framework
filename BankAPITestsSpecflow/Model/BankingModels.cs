using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace BankSystem.Tests.Model
{
    [Binding]
    public class CreateUserRequest
    {
        [JsonProperty("name")]
        public required string Name { get; set; }
    }

    [Binding]
    public class User
    {
        public required string userId { get; set; }
        public required string userName { get; set; }
        public required List<Account> Accounts { get; set; }
    }

    public class UserList
    {
        public required List<UserId> Users { get; set; }
    }

    public class UserId
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
    }

    public class Account
    {
        public required string accountId { get; set; }
        public required decimal balance { get; set; }
    }

    public class UpdateRequest
    {
        public required decimal Amount { get; set; }
    }

    public class BankingModels
    {
        [JsonProperty("userId")]
        public required string UserId { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }
        [JsonProperty("accountId")]
        public required string AccountId { get; set; }
        [JsonProperty("message")]
        public required string Message { get; set; }
    }

    public class CreateAccountResponse
    {
        [JsonProperty("accountId")]
        public required string AccountId { get; set; }
        [JsonProperty("balance")]
        public required decimal Balance { get; set; }
        [JsonProperty("message")]
        public required string Message { get; set; }
    }

    public class Message
    {
        [JsonProperty("message")]
        public required String msg { get; set; }
    }
}
