using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xlsx.Pipes
{
    public class RoundPipe : WholeSaleXlsxValidator
    {
        public RoundPipe(IPipelineFactory<(string value, int rowIndex), XlsxValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        public override Pipeline Rule => Pipeline.ROUND;

        protected override void Validate(IValidationObjectAdapter<(string value, int rowIndex)> input)
        {
            if (decimal.TryParse(input.Value.value, out var decimalVal))
            {
                ReplaceValue(input.Value, ValidationFail.VALUE_ROUNDED, decimalVal.ToString("####"));
            }
        }
    }
}