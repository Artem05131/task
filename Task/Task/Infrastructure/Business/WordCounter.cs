using Task.Infrastructure.Interfaces;
using Task.Infrastructure.Models;

namespace Task.Infrastructure.Business
{
    public class WordCounter : IWordCounter
    {
        private static ICollection<string> englishArticlesAndPropositions;

        static WordCounter()
        {
            englishArticlesAndPropositions = new[] 
            {
                "an", "a", "the", "in", "at", "on", "to",
                "they", "you", "i", "me", "your",
                "will", "is", "are", "were", "was", "be", "been", "have"
            };
        }

        public WordCountResult CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            var words = GetWords(text).ToArray();

            return new WordCountResult
            {
                TotalWordsCount = words.Length,
                WordDestinyResultGroups = Enumerable.Range(1, 3)
                    .Select(groupCount => new WordDensityGroupResult
                    {
                        WordsGroupCount = groupCount,
                        WordDestinyResults = CountOccurrenceResult(GroupWordsByCount(groupCount != 1 ? words : ExcludeWords(words), groupCount), words.Length)
                    })
            };
        }

        public static IEnumerable<WordDensityResult> CountOccurrenceResult(IEnumerable<string> source, int countOfWords)
        {
            return source.GroupBy(t => t)
                .Select(g =>
                {
                    var @string = g.Key;
                    var count = g.Count();
                    return new WordDensityResult
                    {
                        OccurrenceCount = count,
                        OccurrencePercentage = 100f / (countOfWords / count),
                        Value = @string
                    };
                }).OrderByDescending(x => x.OccurrenceCount);
        }

        private static IEnumerable<string> GroupWordsByCount(IEnumerable<string> words, int groupCount) =>
                words.Select((x, i) => new { Key = i / groupCount, Value = x })
                    .GroupBy(x => x.Key, x => x.Value, (k, g) => string.Join(" ", g));

        private static IEnumerable<string> ExcludeWords(IEnumerable<string> words) => words.Where(x => !englishArticlesAndPropositions.Contains(x));
        private static IEnumerable<string> GetWords(string text) => text.Split(' ').Select(word => word.TrimEnd('.', ',').ToLower());
    }
}
