using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Infrastructure.Contracts;

namespace Validator_Demo.ValidationPipeline.Xlsx.Pipes
{
    public sealed class RequiredPipe : WholeSaleXlsxValidator
    {
        public override Pipeline Rule => Pipeline.REQUIRED;

        protected override void Validate(IValidationObjectAdapter<(string value, int rowIndex)> input)
        {
            if (string.IsNullOrEmpty(input.Value.value))
                Fail(input.Value, ValidationFail.VALUE_MISSING);
        }

        public RequiredPipe(IPipelineFactory<(string value, int rowIndex), XlsxValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        protected override bool ColumnValid()
        {
            if (Context.DataProvider.ColumnExist(Context.Field.Name)) return true;
            Context.Report.Messages.Add($"Обязательный столбец {Context.Field.Name} отсутствует");
            return false;
        }
    }
}