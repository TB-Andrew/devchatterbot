using System;
using System.Linq;
using DevChatter.Bot.Core.Commands;
using DevChatter.Bot.Core.Commands.Trackers;
using DevChatter.Bot.Core.Data;
using DevChatter.Bot.Core.Data.Model;
using DevChatter.Bot.Core.Events.Args;
using DevChatter.Bot.Core.Systems.Chat;

namespace UnitTests.Fakes
{
    public class FakeCommand : BaseCommand
    {
        public FakeCommand(IRepository repository, bool isEnabled)
            : base(repository, UserRole.Everyone, isEnabled)
        {
            NotifyWordsModified();
        }

        public override CommandUsage Process(IChatClient chatClient, CommandReceivedEventArgs eventArgs)
        {
            ProcessWasCalled = true;
            return new CommandUsage(eventArgs?.ChatUser.DisplayName, DateTimeOffset.UtcNow, this);
        }

        public bool ProcessWasCalled { get; set; }
        public string CommandText => CommandWords.First();
    }
}
