using Task.Infrastructure.Models;

namespace Task.Infrastructure.Interfaces
{
    public interface IWordCounter
    {
        WordCountResult CountWords(string text);
    }
}
