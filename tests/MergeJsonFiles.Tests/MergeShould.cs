using FluentAssertions;
using Newtonsoft.Json.Linq;
using System.IO.Abstractions.TestingHelpers;
using Xunit;

namespace MergeJsonFiles.Tests
{
    public class MergeShould
    {
        private const string LeftPath = "left.json";
        private const string RightPath = "right.json";
        private readonly MockFileSystem _mockFileSystem;
        private readonly Options _options;

        public MergeShould()
        {
            _mockFileSystem = new MockFileSystem();
            _options = new Options()
            {
                LeftPath = LeftPath,
                RightPath = RightPath,
                OutputPath = "merged.json"
            };
        }

        [Fact]
        public void merge_with_null_ignore_option()
        {
            WriteFiles(
                @"
{
  ""name"": ""Sergio"",
  ""age"": 44,
  ""address"": {
    ""city"": ""Madrid"",
    ""zipCode"": ""28054""
  }
}
",
                @"
{
  ""name"": ""Carmen"",
  ""age"": null,
  ""address"": {
    ""city"": ""Málaga"",
    ""country"": ""España""
  }
}
");

            var merger = new Merger(_mockFileSystem);

            _options.MergeArrayHandling = default;
            _options.MergeNullValueHandling = MergeNullValueHandling.Ignore;

            merger.Merge(_options);

            _mockFileSystem.File.ReadAllText(_options.OutputPath).Trim().Should().Be(
                @"
{
  ""name"": ""Carmen"",
  ""age"": 44,
  ""address"": {
    ""city"": ""Málaga"",
    ""zipCode"": ""28054"",
    ""country"": ""España""
  }
}
".Trim());
        }

        [Fact]
        public void merge_with_null_merge_option()
        {
            WriteFiles(
                @"
{
  ""name"": ""Sergio"",
  ""age"": 44,
  ""age"": null,
  ""address"": {
    ""city"": ""Madrid"",
    ""zipCode"": ""28054""
  }
}
",
                @"
{
  ""name"": ""Carmen"",
  ""address"": {
    ""city"": ""Málaga"",
    ""country"": ""España""
  }
}
");

            var merger = new Merger(_mockFileSystem);

            _options.MergeArrayHandling = default;
            _options.MergeNullValueHandling = MergeNullValueHandling.Merge;

            merger.Merge(_options);

            _mockFileSystem.File.ReadAllText(_options.OutputPath).Trim().Should().Be(
                @"
{
  ""name"": ""Carmen"",
  ""age"": null,
  ""address"": {
    ""city"": ""Málaga"",
    ""zipCode"": ""28054"",
    ""country"": ""España""
  }
}
".Trim());
        }

        private void WriteFiles(string leftContents, string rightContents)
        {
            var leftMockFile = new MockFileData(leftContents);
            _mockFileSystem.RemoveFile(LeftPath);
            _mockFileSystem.AddFile(LeftPath, leftMockFile);

            var rightMockFile = new MockFileData(rightContents);
            _mockFileSystem.RemoveFile(RightPath);
            _mockFileSystem.AddFile(RightPath, rightMockFile);
        }
    }
}
