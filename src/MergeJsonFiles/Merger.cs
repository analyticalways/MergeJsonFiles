using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO.Abstractions;

namespace MergeJsonFiles
{
    public class Merger
    {
        private readonly IFileSystem _fileSystem;

        public Merger() : this(new FileSystem())
        {
        }

        public Merger(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public void Merge(Options options)
        {
            // https://www.newtonsoft.com/json/help/html/MergeJson.htm
            using var leftReader = _fileSystem.File.OpenText(options.LeftPath);
            var left = (JObject)JToken.ReadFrom(new JsonTextReader(leftReader));
            using var rightReader = _fileSystem.File.OpenText(options.RightPath);
            var right = (JObject)JToken.ReadFrom(new JsonTextReader(rightReader));
            left.Merge(right, new JsonMergeSettings
            {
                MergeArrayHandling = options.MergeArrayHandling,
                MergeNullValueHandling = options.MergeNullValueHandling
            });
            _fileSystem.File.WriteAllText(options.OutputPath, left.ToString());
            Console.WriteLine($"Output written to {options.OutputPath}");
        }
    }
}
