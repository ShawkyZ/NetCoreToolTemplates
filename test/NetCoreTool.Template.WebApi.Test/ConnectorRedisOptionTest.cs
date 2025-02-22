using System.Collections.Generic;
using Steeltoe.NetCoreTool.Template.WebApi.Test.Models;
using Xunit.Abstractions;

namespace Steeltoe.NetCoreTool.Template.WebApi.Test
{
    public class ConnectorRedisOptionTest : ProjectOptionTest
    {
        public ConnectorRedisOptionTest(ITestOutputHelper logger) : base("connector-redis",
            "Add a connector for Redis data stores", logger)
        {
        }

        protected override void AssertPackageReferencesHook(ProjectOptions options, List<(string, string)> packages)
        {
            packages.Add(("Microsoft.Extensions.Caching.StackExchangeRedis", "3.1.*"));
            packages.Add(("Steeltoe.Connector.ConnectorCore", "$(SteeltoeVersion)"));
        }

        protected override void AssertStartupSnippetsHook(ProjectOptions options, List<string> snippets)
        {
            snippets.Add("Steeltoe.Connector.Redis");
            snippets.Add("services.AddDistributedRedisCache");
        }
    }
}
