using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xlsx.Pipes
{
    public sealed class DefaultPipe : WholeSaleXlsxValidator
    {
        public DefaultPipe(IPipelineFactory<(string value, int rowIndex), XlsxValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        public override Pipeline Rule => Pipeline.DEFAULT;

        protected override void Validate(IValidationObjectAdapter<(string value, int rowIndex)> input)
        {
        }
    }
}