using System.Collections.Generic;
using System.Text.RegularExpressions;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xlsx.Pipes
{
    public sealed class RegexPipe : WholeSaleXlsxValidator
    {
        public override Pipeline Rule => Pipeline.REGEX;

        public RegexPipe(IPipelineFactory<(string value, int rowIndex), XlsxValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        protected override void Validate(IValidationObjectAdapter<(string value, int rowIndex)> input)
        {
            if (string.IsNullOrEmpty(input.Value.value))
            {
                if (OptionalValueWarningDisabled)
                    return;
                Fail(input.Value, ValidationFail.OPTIONAL_VALUE_MISSING, FailLevel.Warning);
                return;
            }

            if (!new Regex(Context.AttributeProvider.CellPattern).IsMatch(input.Value.value))
                Fail(input.Value, ValidationFail.REGEX_PATTERN_FAIL);
        }
    }
}