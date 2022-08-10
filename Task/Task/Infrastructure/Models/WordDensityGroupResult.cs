namespace Task.Infrastructure.Models
{
    public class WordDensityGroupResult
    {
        public int WordsGroupCount { get; set; }
        public IEnumerable<WordDensityResult> WordDestinyResults { get; set; }
    }
}
