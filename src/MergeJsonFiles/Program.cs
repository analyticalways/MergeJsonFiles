using CommandLine;

namespace MergeJsonFiles
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(options =>
                {
                    new Merger().Merge(options);
                });
        }
    }
}
