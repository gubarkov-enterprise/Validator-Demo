using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Attributes;
using static Validator_Demo.RegexHelper;

namespace Validator_Demo.Models
{
    public class Book
    {
        [ValidationColumn(
            ValidatePipeline = new[]
            {
                Pipeline.REQUIRED
            }
        )]
        public string Title { get; set; }

        [ValidationColumn(
            CellPattern = UrlPattern,
            ValidatePipeline = new[]
            {
                Pipeline.REQUIRED,
                Pipeline.REGEX,
            }
        )]
        [ValidationFailLevel(Pipeline.REQUIRED, FailLevel.None)]

        public string AuthorSite { get; set; }
    }
}