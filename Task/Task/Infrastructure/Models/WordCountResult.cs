namespace Task.Infrastructure.Models
{
    public class WordCountResult
    {
        public int TotalWordsCount { get; set; }
        public IEnumerable<WordDensityGroupResult> WordDestinyResultGroups { get; set; }
    }
}
