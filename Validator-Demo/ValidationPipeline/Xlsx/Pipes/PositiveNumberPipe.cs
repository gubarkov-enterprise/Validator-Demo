using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xlsx.Pipes
{
    public class PositiveNumberPipe : WholeSaleXlsxValidator
    {
        public PositiveNumberPipe(IPipelineFactory<(string value, int rowIndex), XlsxValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        public override Pipeline Rule => Pipeline.POSITIVE_NUMBER;

        protected override void Validate(IValidationObjectAdapter<(string value, int rowIndex)> input)
        {
            if (!decimal.TryParse(input.Value.value, out var value)) return;
            if (value < 0)
                Fail(input.Value, ValidationFail.NOT_POSITIVE_NUMBER);
        }
    }
}