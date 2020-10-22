using CommandLine;
using Newtonsoft.Json.Linq;

namespace MergeJsonFiles
{
    public class Options
    {
        [Option('l', "leftpath", Required = true, HelpText = "Specifies the file path to use on the left side.")]
        public string LeftPath { get; set; }

        [Option('r', "rightpath", Required = true, HelpText = "Specifies the file path to use on the right side.")]
        public string RightPath { get; set; }

        [Option('o', "outputpath", Required = true, HelpText = "Specifies the output file path.")]
        public string OutputPath { get; set; }

        [Option("mergearrayhandling", Required = false, HelpText = "Specifies MergeArrayHandling property of JsonMergeSettings class.")]
        public MergeArrayHandling MergeArrayHandling { get; set; }

        [Option("mergenullvaluehandling", Required = false, HelpText = "Specifies MergeNullValueHandling property of JsonMergeSettings class.")]
        public MergeNullValueHandling MergeNullValueHandling { get; set; }
    }
}
