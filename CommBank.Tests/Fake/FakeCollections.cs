using CommBank.Models;
using CommBank_Server.Models;
using CommBank.Services;
using CommBank_Server.Services;

namespace CommBank.Tests.Fake
{
    public class FakeCollections
    {
        List<Account> accounts;
        List<Goal> goals;
        List<Tag> tags;
        List<Transaction> transactions;
        List<User> users;


        public FakeCollections()
        {
            accounts = new()
            {
                new()
                {
                    Id = "1",
                    Name = "Tag's GoalSaver"
                },

                new()
                {
                    Id = "2",
                    Name = "Trot's GoalSaver"
                }
            };

            goals = new()
            {
                new()
                {
                    Id = "1",
                    Name = "House Down Payment"
                },

                new()
                {
                    Id = "2",
                    Name = "Tesla Model Y"
                },

                new()
                {
                    Id = "3",
                    Name = "Trip to London"
                },
            };

            tags = new()
            {
                new()
                {
                    Id = "1",
                    Name = "Groceries"
                },

                new()
                {
                    Id = "2",
                    Name = "Entertainment"
                }
            };

            transactions = new()
            {
                new()
                {
                    Id = "1"
                },

                new()
                {
                    Id = "2"
                }
            };

            users = new()
            {
                new()
                {
                    Id = "1",
                    Username = "Tag",
                    Email = "tag@example.com"
                },

                new()
                {
                    Id = "2",
                    Username = "Trot",
                    Email = "trot@example.com"
                },

                new()
                {
                    Id = "3",
                    Username = "Tugg",
                    Email = "tugg@example.com"
                }
            };
        }

        public List<Account> GetAccounts()
        {
            return accounts;
        }

        public List<Goal> GetGoals()
        {
            return goals;
        }

        public List<Tag> GetTags()
        {
            return tags;
        }

        public List<Transaction> GetTransactions()
        {
            return transactions;
        }

        public List<User> GetUsers()
        {
            return users;
        }
    }
}