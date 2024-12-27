using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace OutboxPattern.Core.Infrastructure
{
    public class CollectionStringConverter : ValueConverter<List<string>, string>
    {
        public CollectionStringConverter() : base(
            (List<string> list) => string.Join(',', list),
            (string text) => text == null ? new List<string>() : text.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList(), 
            null)
        {
        }
    }
}
