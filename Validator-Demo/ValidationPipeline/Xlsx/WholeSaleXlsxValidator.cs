using System.Collections.Generic;
using Validator_Demo.ValidationPipeline.Infrastructure;
using Validator_Demo.ValidationPipeline.Xlsx.Report;

namespace Validator_Demo.ValidationPipeline.Xlsx
{
    public abstract class WholeSaleXlsxValidator : XlsxValidator<(string value, int rowIndex), XlsxValidationContext>
    {
        protected WholeSaleXlsxValidator(IPipelineFactory<(string value, int rowIndex), XlsxValidationContext> factory,
            LinkedListNode<Pipeline> node) : base(factory, node)
        {
        }

        protected override bool ColumnValid() =>
            Context.DataProvider.ColumnExist(Context.Field.Name);


        protected override void Fail((string value, int rowIndex) cell, ValidationFail failType,
            FailLevel level = FailLevel.Critical)
        {
            Context.Report.ReportInvalidField(new InvalidField(cell.rowIndex, Context.Field.Name,
                Context.DataProvider.ColumnIndex(Context.Field.Name), failType, level));
        }

        protected virtual void ReplaceValue((string value, int rowIndex) cell, ValidationFail failType,
            string replacedValue,
            FailLevel level = FailLevel.RenderedValueReplaced)
        {
            Context.Report.ReportInvalidField(new InvalidField(cell.rowIndex, Context.Field.Name,
                Context.DataProvider.ColumnIndex(Context.Field.Name), failType, replacedValue, level));
        }
    }
}